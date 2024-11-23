using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite CollectionsList object
/// </summary>
/// <param name="Total">Total number of collections documents that matched your query</param>
/// <param name="Collections">List of collections</param>
public record CollectionsList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("collections")] IReadOnlyList<Collection> Collections
);
