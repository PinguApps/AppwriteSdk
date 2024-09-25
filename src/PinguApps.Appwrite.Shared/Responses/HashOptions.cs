using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// Password hashing algorithm information
/// </summary>
/// <param name="Type">The hashing algorithm</param>
/// <param name="MemoryCost">The memory cost of the hash</param>
/// <param name="TimeCost">The time cost of the hash</param>
/// <param name="Threads">The threads used</param>
public record HashOptions(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("memoryCost")] long MemoryCost,
    [property: JsonPropertyName("timeCost")] int TimeCost,
    [property: JsonPropertyName("threads")] int Threads
);
