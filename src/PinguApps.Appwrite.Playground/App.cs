﻿using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Realtime;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Playground;
internal class App
{
    private readonly Client.IClientAppwriteClient _client;
    private readonly Server.Clients.IServerAppwriteClient _server;
    private readonly IRealtimeClient _realtimeClient;
    private readonly string? _session;

    public App(Client.IClientAppwriteClient client, Server.Clients.IServerAppwriteClient server, IRealtimeClient realtimeClient, IConfiguration config)
    {
        _client = client;
        _server = server;
        _realtimeClient = realtimeClient;
        _session = config.GetValue<string>("Session");
    }

    public record Table1
    {
        [JsonPropertyName("test")] public string? Test { get; init; }
        [JsonPropertyName("boolAttribute")] public bool BoolAttribute { get; init; }
    }

    public async Task Run(string[] args)
    {
        using (_realtimeClient.Subscribe<Document<Table1>>("documents", x =>
        {
            Console.WriteLine(x.Payload);
        }))
        {
            await Task.Delay(5000);

            _realtimeClient.SetSession(_session);

            Console.ReadKey();
        }
    }
}
