using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class UpdateMfaRequest : UserIdBaseRequest<UpdateMfaRequest, UpdateMfaRequestValidator>
{
    /// <summary>
    /// Enable or disable MFA on a user account
    /// </summary>
    [JsonPropertyName("mfa")]
    public bool Mfa { get; set; }
}
