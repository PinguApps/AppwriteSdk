using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class UpdateNameRequest : UserIdBaseRequest<UpdateNameRequest, UpdateNameRequestValidator>
{
    /// <summary>
    /// User name. Max length: 128 chars
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
}
