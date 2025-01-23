using System;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Realtime.Models;
public class WebSocketOptions
{
    [JsonPropertyName("reconnectInterval")]
    public TimeSpan ReconnectInterval { get; set; } = TimeSpan.FromSeconds(30);

    [JsonPropertyName("heartbeatInterval")]
    public TimeSpan HeartbeatInterval { get; set; } = TimeSpan.FromSeconds(20);

    [JsonPropertyName("maxRetryAttempts")]
    public int MaxRetryAttempts { get; set; } = 5;

    [JsonPropertyName("retrySleepDurationProvider")]
    public Func<int, TimeSpan> RetrySleepDurationProvider { get; set; } = retryAttempt => TimeSpan.FromSeconds(((retryAttempt - 1) * 2) + 1);
}
