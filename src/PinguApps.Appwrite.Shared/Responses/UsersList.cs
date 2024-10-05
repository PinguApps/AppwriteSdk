using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Apwrite Users List object
/// </summary>
/// <param name="Total">Total number of users documents that matched your query</param>
/// <param name="Users">List of users. Can be one of: <see cref="User"/></param>
public record UsersList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("users")] IReadOnlyList<User> Users
);
