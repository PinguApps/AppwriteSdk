using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Logs List object
/// </summary>
/// <param name="Total">Total number of logs documents that matched your query.</param>
/// <param name="Logs">List of logs. Can be one of: <see cref="LogModel"/></param>
public record LogsList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("logs")] IReadOnlyList<LogModel> Logs
);
