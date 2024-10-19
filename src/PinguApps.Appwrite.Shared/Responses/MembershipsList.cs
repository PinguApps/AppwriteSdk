using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite MembershipsList object
/// </summary>
/// <param name="Total">Total number of memberships documents that matched your query</param>
/// <param name="Memberships">List of memberships. Can be one of: <see cref="Membership"/></param>
public record MembershipsList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("memberships")] IReadOnlyList<Membership> Memberships
);
