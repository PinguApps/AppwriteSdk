using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;
public class VerifyAuthenticatorRequest : BaseRequest<VerifyAuthenticatorRequest, VerifyAuthenticatorRequestValidator>
{
    public string Otp { get; set; } = string.Empty;
}
