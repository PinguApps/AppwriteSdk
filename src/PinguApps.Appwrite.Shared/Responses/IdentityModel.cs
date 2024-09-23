using System;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// 
/// </summary>
/// <param name="Id">Identity ID</param>
/// <param name="CreatedAt">Identity creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Identity update date in ISO 8601 format</param>
/// <param name="UserId">User ID</param>
/// <param name="Provider">Identity Provider</param>
/// <param name="ProviderUid">ID of the User in the Identity Provider</param>
/// <param name="ProviderEmail">Email of the User in the Identity Provider</param>
/// <param name="ProviderAccessToken">Identity Provider Access Token</param>
/// <param name="ProviderAccessTokenExpiry">The date of when the access token expires in ISO 8601 format</param>
/// <param name="ProviderRefreshToken">Identity Provider Refresh Token</param>
public record IdentityModel(
    [property: JsonPropertyName("$id")] string Id,
    [property: JsonPropertyName("$createdAt")] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt")] DateTime UpdatedAt,
    [property: JsonPropertyName("userId")] string UserId,
    [property: JsonPropertyName("provider")] string Provider,
    [property: JsonPropertyName("providerUid")] string ProviderUid,
    [property: JsonPropertyName("providerEmail")] string ProviderEmail,
    [property: JsonPropertyName("providerAccessToken")] string ProviderAccessToken,
    [property: JsonPropertyName("providerAccessTokenExpiry")] DateTime ProviderAccessTokenExpiry,
    [property: JsonPropertyName("providerRefreshToken")] string ProviderRefreshToken
);
