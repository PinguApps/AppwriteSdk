using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Realtime.Models;

public record RealtimeRequest(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("data")] RealtimeRequestAuthenticate? Data
);
