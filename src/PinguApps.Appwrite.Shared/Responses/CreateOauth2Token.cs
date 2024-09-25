using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// A Create Oauth2 Token object
/// </summary>
/// <param name="Uri">The Uri that you should redirect the user towards to begin Oauth2 authentication</param>
public record CreateOauth2Token(
    [property: JsonPropertyName("uri")] string Uri
);
