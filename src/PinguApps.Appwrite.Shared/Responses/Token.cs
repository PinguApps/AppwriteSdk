using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Token object
/// </summary>
/// <param name="Id">Token ID</param>
/// <param name="CreatedAt">Token creation date in ISO 8601 format</param>
/// <param name="UserId">User ID</param>
/// <param name="Secret">Token secret key. This will return an empty string unless the response is returned using an API key or as part of a webhook payload</param>
/// <param name="ExpiresAt">Token expiration date in ISO 8601 format</param>
/// <param name="Phrase">Security phrase of a token. Empty if security phrase was not requested when creating a token. It includes randomly generated phrase which is also sent in the external resource such as email</param>
public record Token(
    [property: JsonPropertyName("$id")] string Id,
    [property: JsonPropertyName("$createdAt"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime CreatedAt,
    [property: JsonPropertyName("userId")] string UserId,
    [property: JsonPropertyName("secret")] string Secret,
    [property: JsonPropertyName("expire"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime ExpiresAt,
    [property: JsonPropertyName("phrase")] string Phrase
);
