using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class DeleteAuthenticatorRequest : UserIdBaseRequest<DeleteAuthenticatorRequest, DeleteAuthenticatorRequestValidator>
{
    /// <summary>
    /// Type of authenticator
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;
}
