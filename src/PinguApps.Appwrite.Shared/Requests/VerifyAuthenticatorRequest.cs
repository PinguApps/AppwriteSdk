using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;
public class VerifyAuthenticatorRequest : BaseRequest<VerifyAuthenticatorRequest, VerifyAuthenticatorRequestValidator>
{
    [JsonPropertyName("otp")]
    public string Otp { get; set; } = string.Empty;
}
