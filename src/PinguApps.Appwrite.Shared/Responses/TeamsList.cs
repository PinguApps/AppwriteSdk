using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite TeamsList object
/// </summary>
/// <param name="Total">Total number of teams documents that matched your query</param>
/// <param name="Teams">List of teams. Can be one of: <see cref="Team"/></param>
public record TeamsList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("teams")] IReadOnlyList<Team> Teams
);
