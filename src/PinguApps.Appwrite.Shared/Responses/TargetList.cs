using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Target List object
/// </summary>
/// <param name="Total">Total number of targets documents that matched your query</param>
/// <param name="Targets">List of targets. Can be one of: <see cref="Target"/></param>
public record TargetList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("targets")] IReadOnlyList<Target> Targets
);
