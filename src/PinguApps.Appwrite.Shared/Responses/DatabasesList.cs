using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Databases List object
/// </summary>
/// <param name="Total">Total number of databases documents that matched your query</param>
/// <param name="Databases">List of databases. Can be one of: <see cref="Database"/></param>
public record DatabasesList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("databases")] IReadOnlyList<Database> Databases
);
