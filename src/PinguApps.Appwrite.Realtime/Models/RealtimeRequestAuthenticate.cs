using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Realtime.Models;

public record RealtimeRequestAuthenticate(
    [property: JsonPropertyName("session")] string? Session
);
