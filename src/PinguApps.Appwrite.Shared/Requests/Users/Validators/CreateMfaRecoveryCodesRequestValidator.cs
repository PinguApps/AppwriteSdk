using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateMfaRecoveryCodesRequestValidator : AbstractValidator<CreateMfaRecoveryCodesRequest>
{
    public CreateMfaRecoveryCodesRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<CreateMfaRecoveryCodesRequest, CreateMfaRecoveryCodesRequestValidator>());
    }
}
