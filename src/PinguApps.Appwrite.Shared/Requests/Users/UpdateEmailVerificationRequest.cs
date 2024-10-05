using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class UpdateEmailVerificationRequest : UserIdBaseRequest<UpdateEmailVerificationRequest, UpdateEmailVerificationRequestValidator>
{
    /// <summary>
    /// User email verification status
    /// </summary>
    [JsonPropertyName("emailVerification")]
    public bool EmailVerification { get; set; }
}
