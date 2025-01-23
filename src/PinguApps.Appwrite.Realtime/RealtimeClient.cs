using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PinguApps.Appwrite.Realtime.Models;
using PinguApps.Appwrite.Shared;
using Polly;
using Websocket.Client;

namespace PinguApps.Appwrite.Realtime;
internal class RealtimeClient : IAsyncDisposable, IRealtimeClient
{
    private readonly ILogger<RealtimeClient> _logger;
    private readonly Config _config;
    private readonly WebSocketOptions _options;
    private readonly IDisposable _heartbeatSubscription;
    private WebsocketClient? _client;
    private string? _session;
    private readonly ConcurrentDictionary<string, ConcurrentBag<Subscription>> _subscriptions = new();
    private readonly Subject<Unit> _reconnectTrigger = new();
    private readonly AsyncPolicy _retryPolicy;

    private record Subscription(Type PayloadType, Delegate Callback);

    public bool IsConnected => _client?.IsRunning == true;

    public RealtimeClient(IOptions<WebSocketOptions> options, ILogger<RealtimeClient> logger, Config config)
    {
        _logger = logger;
        _config = config;
        _options = options.Value;

        _retryPolicy = Policy.Handle<Exception>().WaitAndRetryAsync(_options.MaxRetryAttempts, _options.RetrySleepDurationProvider,
                (ex, timeSpan) => _logger.LogWarning(ex, "Retry attempt after {Delay}s", timeSpan.TotalSeconds));

        _heartbeatSubscription = Observable.Interval(_options.HeartbeatInterval).Subscribe(async _ =>
            {
                try
                {
                    await SendHeartbeat();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Heartbeat failed");
                }
            });

        _reconnectTrigger.Throttle(TimeSpan.FromSeconds(1)).Subscribe(async _ =>
            {
                try
                {
                    if (_client?.IsRunning == true)
                    {
                        await _client.Reconnect();
                    }
                    else
                    {
                        await ConnectAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during reconnection");
                }
            });
    }

    public async Task DisconnectAsync()
    {
        if (_client is not null)
        {
            _subscriptions.Clear();
            await _client.Stop(WebSocketCloseStatus.NormalClosure, "Client disconnecting");
            _client.Dispose();
            _client = null;
        }
    }

    private async Task ConnectAsync()
    {
        var url = BuildWebSocketUrl();

        var factory = new Func<ClientWebSocket>(() =>
        {
            var client = new ClientWebSocket();
            client.Options.SetRequestHeader("x-sdk-name", ".NET");
            client.Options.SetRequestHeader("x-sdk-platform", "realtime");
            client.Options.SetRequestHeader("x-sdk-language", "dotnet");
            client.Options.SetRequestHeader("x-sdk-version", Constants.Version);
            client.Options.SetRequestHeader("X-Appwrite-Response-Format", "1.6.0");
            client.Options.SetRequestHeader("X-Appwrite-Project", _config.ProjectId);
            client.Options.SetRequestHeader("X-Appwrite-Session", _session);

            return client;
        });

        _client = new WebsocketClient(url, factory)
        {
            ReconnectTimeout = _options.ReconnectInterval,
            ErrorReconnectTimeout = _options.ReconnectInterval
        };

        _client.MessageReceived.Subscribe(HandleMessage);

        _client.DisconnectionHappened.Subscribe(info =>
        {
            _logger.LogWarning("WebSocket disconnected: {Type}", info.Type);
            _reconnectTrigger.OnNext(Unit.Default);
        });

        await _retryPolicy.ExecuteAsync(async () =>
        {
            await _client.Start();
            _logger.LogInformation("WebSocket connected successfully");
        });
    }

    public void SetSession(string? session)
    {
        _session = session;

        if (_client?.IsRunning == true && session != null)
        {
            SendAuthenticationMessage(session).ConfigureAwait(false);
        }
    }

    private Uri BuildWebSocketUrl()
    {
        var channels = string.Join("&", _subscriptions.Keys.Select(x => $"channels[]={Uri.EscapeDataString(x)}"));

        return new UriBuilder(_config.Endpoint)
        {
            Query = $"project={Uri.EscapeDataString(_config.ProjectId)}&{channels}"
        }.Uri;
    }

    private void HandleMessage(ResponseMessage message)
    {
        try
        {
            if (message.MessageType != WebSocketMessageType.Text)
            {
                return;
            }

            var response = JsonSerializer.Deserialize<RealtimeMessage>(message.Text!);

            if (response is null)
            {
                return;
            }

            switch (response.Type)
            {
                case "connected":
                    HandleConnectedMessage(response.Data);
                    break;
                case "event":
                    HandleEventMessage(response.Data);
                    break;
                case "error":
                    HandleErrorMessage(response.Data);
                    break;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error handling message");
        }
    }

    private void HandleConnectedMessage(JsonElement data)
    {
        var connected = JsonSerializer.Deserialize<RealtimeResponseConnected>(data.GetRawText());

        if (_session is not null && connected?.User == null)
        {
            SendAuthenticationMessage(_session).ConfigureAwait(false);
        }
    }

    private void HandleEventMessage(JsonElement data)
    {
        var eventData = JsonSerializer.Deserialize<RealtimeResponseEvent<JsonElement>>(data.GetRawText());

        if (eventData is null)
        {
            return;
        }

        foreach (var channel in eventData.Channels)
        {
            if (_subscriptions.TryGetValue(channel, out var subs))
            {
                foreach (var sub in subs)
                {
                    try
                    {
                        var payload = eventData.Payload.Deserialize(sub.PayloadType);

                        var eventType = typeof(RealtimeResponseEvent<>).MakeGenericType(sub.PayloadType);

                        var typedEvent = Activator.CreateInstance(eventType, eventData.Events, eventData.Channels, eventData.Timestamp, payload);

                        sub.Callback.DynamicInvoke(typedEvent);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error invoking subscription callback");
                    }
                }
            }
        }
    }

    private void HandleErrorMessage(JsonElement data)
    {
        var error = JsonSerializer.Deserialize<RealtimeResponseError>(data.GetRawText());

        _logger.LogError("WebSocket error: {Message} (Code: {Code})", error?.Message, error?.Code);
    }

    private async Task SendHeartbeat()
    {
        try
        {
            if (_client?.IsRunning == true)
            {
                await _client.SendInstant(JsonSerializer.Serialize(new { type = "ping" }));
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending heartbeat");
        }
    }

    private async Task SendAuthenticationMessage(string session)
    {
        var message = new RealtimeRequest("authentication", new RealtimeRequestAuthenticate(session));

        await _client!.SendInstant(JsonSerializer.Serialize(message));
    }

    public IDisposable Subscribe<T>(string channel, Action<RealtimeResponseEvent<T>> callback) => Subscribe([channel], callback);

    public IDisposable Subscribe<T>(List<string> channels, Action<RealtimeResponseEvent<T>> callback)
    {
        var subscription = new Subscription(typeof(T), callback);

        foreach (var channel in channels)
        {
            _subscriptions.AddOrUpdate(channel, _ => [subscription], (_, subs) =>
                {
                    subs.Add(subscription);
                    return subs;
                });
        }

        EnsureConnected();

        return new SubscriptionHandler(this, channels, subscription);
    }

    private async void EnsureConnected()
    {
        if (!IsConnected)
        {
            await ConnectAsync();
        }
    }

    private class SubscriptionHandler : IDisposable
    {
        private readonly RealtimeClient _client;
        private readonly List<string> _channels;
        private readonly Subscription _subscription;

        public SubscriptionHandler(RealtimeClient client, List<string> channels, Subscription subscription)
        {
            _client = client;
            _channels = channels;
            _subscription = subscription;
        }

        public void Dispose()
        {
            foreach (var channel in _channels)
            {
                if (_client._subscriptions.TryGetValue(channel, out var subs))
                {
                    var updatedSubs = new ConcurrentBag<Subscription>(subs.Where(x => x != _subscription));

                    if (updatedSubs.IsEmpty)
                    {
                        _client._subscriptions.TryRemove(channel, out _);
                    }
                    else
                    {
                        _client._subscriptions.TryUpdate(channel, updatedSubs, subs);
                    }
                }
            }
        }
    }

    public async ValueTask DisposeAsync()
    {
        _heartbeatSubscription.Dispose();
        await DisconnectAsync();
    }
}
