using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Realtime.Models;
public record RealtimeResponseEvent<T>(
    [property: JsonPropertyName("events")] IReadOnlyList<string> Events,
    [property: JsonPropertyName("channels")] IReadOnlyList<string> Channels,
    [property: JsonPropertyName("timestamp")] long Timestamp,
    [property: JsonPropertyName("payload")] T Payload
);
