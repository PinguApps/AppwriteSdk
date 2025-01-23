using System.Text.Json;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Realtime.Models;
public record RealtimeMessage(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("data")] JsonElement Data
);
