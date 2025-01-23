using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Realtime.Models;
public record RealtimeResponseEvent<T>(
    [property: JsonPropertyName("events")] IReadOnlyList<string> Events,
    [property: JsonPropertyName("channels")] IReadOnlyList<string> Channels,
    [property: JsonPropertyName("timestamp"), JsonConverter(typeof(NullableDateTimeConverter))] DateTime? Timestamp,
    [property: JsonPropertyName("payload")] T Payload
);
