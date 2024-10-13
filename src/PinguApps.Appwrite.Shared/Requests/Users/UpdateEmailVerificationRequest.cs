using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for updating a user's email verification
/// </summary>
public class UpdateEmailVerificationRequest : UserIdBaseRequest<UpdateEmailVerificationRequest, UpdateEmailVerificationRequestValidator>
{
    /// <summary>
    /// User email verification status
    /// </summary>
    [JsonPropertyName("emailVerification")]
    public bool EmailVerification { get; set; }
}
