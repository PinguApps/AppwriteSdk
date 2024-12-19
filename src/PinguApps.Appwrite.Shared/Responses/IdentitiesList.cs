using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Identities List object
/// </summary>
/// <param name="Total">Total number of identities documents that matched your query.</param>
/// <param name="Identities">List of identities. Can be one of: <see cref="IdentityModel"/></param>
public record IdentitiesList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("identities")] IReadOnlyList<IdentityModel> Identities
);
