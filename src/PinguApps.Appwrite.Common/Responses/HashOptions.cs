using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;
public record HashOptions(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("memoryCost")] long MemoryCost,
    [property: JsonPropertyName("timeCost")] int TimeCost,
    [property: JsonPropertyName("threads")] int Threads
);
