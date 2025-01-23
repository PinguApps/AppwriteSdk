using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Realtime.Models;
public record RealtimeResponseConnected(
    [property: JsonPropertyName("channels")] IReadOnlyList<string> Channels,
    [property: JsonPropertyName("user")] User? User
);
