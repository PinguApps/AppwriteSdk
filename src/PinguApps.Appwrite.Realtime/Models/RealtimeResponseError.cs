using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Realtime.Models;
public record RealtimeResponseError(
    [property: JsonPropertyName("code")] int Code,
    [property: JsonPropertyName("message")] string Message
);
