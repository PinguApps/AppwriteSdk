using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for updating a user's Mfa
/// </summary>
public class UpdateMfaRequest : UserIdBaseRequest<UpdateMfaRequest, UpdateMfaRequestValidator>
{
    /// <summary>
    /// Enable or disable MFA on a user account
    /// </summary>
    [JsonPropertyName("mfa")]
    public bool Mfa { get; set; }
}
