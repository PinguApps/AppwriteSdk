using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class UpdatePhoneVerificationRequest : UserIdBaseRequest<UpdatePhoneVerificationRequest, UpdatePhoneVerificationRequestValidator>
{
    /// <summary>
    /// User phone verification status
    /// </summary>
    [JsonPropertyName("phoneVerification")]
    public bool PhoneVerification { get; set; }
}
