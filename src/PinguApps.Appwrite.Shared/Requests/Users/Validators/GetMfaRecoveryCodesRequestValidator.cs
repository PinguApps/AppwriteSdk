using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class GetMfaRecoveryCodesRequestValidator : AbstractValidator<GetMfaRecoveryCodesRequest>
{
    public GetMfaRecoveryCodesRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<GetMfaRecoveryCodesRequest, GetMfaRecoveryCodesRequestValidator>());
    }
}
