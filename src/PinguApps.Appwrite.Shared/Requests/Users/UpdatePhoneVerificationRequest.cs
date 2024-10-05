using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for updating a user's phone verification
/// </summary>
public class UpdatePhoneVerificationRequest : UserIdBaseRequest<UpdatePhoneVerificationRequest, UpdatePhoneVerificationRequestValidator>
{
    /// <summary>
    /// User phone verification status
    /// </summary>
    [JsonPropertyName("phoneVerification")]
    public bool PhoneVerification { get; set; }
}
