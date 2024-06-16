using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Client.Models;
public record AppwriteError(
    [property: JsonPropertyName("message")] string Message,
    [property: JsonPropertyName("code")] int Code,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("version")] string Version
);
