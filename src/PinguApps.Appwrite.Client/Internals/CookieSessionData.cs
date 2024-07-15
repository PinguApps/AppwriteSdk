using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Client.Internals;
internal class CookieSessionData
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("secret")]
    public string Secret { get; set; } = default!;
}
