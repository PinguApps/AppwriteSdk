using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Sessions List object
/// </summary>
/// <param name="Total">Total number of sessions documents that matched your query</param>
/// <param name="Sessions">List of sessions. Can be one of: <see cref="Session"/></param>
public record SessionsList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("sessions")] IReadOnlyList<Session> Sessions
);
