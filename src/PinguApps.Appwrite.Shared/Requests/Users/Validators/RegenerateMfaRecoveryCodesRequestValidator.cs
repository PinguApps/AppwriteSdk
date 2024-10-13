using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class RegenerateMfaRecoveryCodesRequestValidator : AbstractValidator<RegenerateMfaRecoveryCodesRequest>
{
    public RegenerateMfaRecoveryCodesRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<RegenerateMfaRecoveryCodesRequest, RegenerateMfaRecoveryCodesRequestValidator>());
    }
}
