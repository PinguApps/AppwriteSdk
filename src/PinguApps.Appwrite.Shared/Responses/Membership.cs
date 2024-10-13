using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Membership object
/// </summary>
/// <param name="Id">Membership ID</param>
/// <param name="CreatedAt">Membership creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Membership update date in ISO 8601 format</param>
/// <param name="UserId">User ID</param>
/// <param name="UserName">User name</param>
/// <param name="UserEmail">User email address</param>
/// <param name="TeamId">Team ID</param>
/// <param name="TeamName">Team name</param>
/// <param name="Invited">Date, the user has been invited to join the team in ISO 8601 format</param>
/// <param name="Joined">Date, the user has accepted the invitation to join the team in ISO 8601 format</param>
/// <param name="Confirm">User confirmation status, true if the user has joined the team or false otherwise</param>
/// <param name="Mfa">Multi factor authentication status, true if the user has MFA enabled or false otherwise</param>
/// <param name="Roles">User list of roles</param>
public record Membership(
    [property: JsonPropertyName("$id")] string Id,
    [property: JsonPropertyName("$createdAt")] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt")] DateTime UpdatedAt,
    [property: JsonPropertyName("userId")] string UserId,
    [property: JsonPropertyName("userName")] string UserName,
    [property: JsonPropertyName("userEmail")] string UserEmail,
    [property: JsonPropertyName("teamId")] string TeamId,
    [property: JsonPropertyName("teamName")] string TeamName,
    [property: JsonPropertyName("invited")] DateTime Invited,
    [property: JsonPropertyName("joined")] DateTime Joined,
    [property: JsonPropertyName("confirm")] bool Confirm,
    [property: JsonPropertyName("mfa")] bool Mfa,
    [property: JsonPropertyName("roles")] List<string> Roles
);
