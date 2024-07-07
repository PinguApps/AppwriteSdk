using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared;

/// <summary>
/// An error thrown from Appwrite
/// </summary>
/// <param name="Message">The message returned from Appwrite</param>
/// <param name="Code">Http Status Code of the response</param>
/// <param name="Type">The type of error thrown</param>
/// <param name="Version">The version of Appwrite throwing the error</param>
public record AppwriteError(
    [property: JsonPropertyName("message")] string Message,
    [property: JsonPropertyName("code")] int Code,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("version")] string Version
);
