using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class UpdatetSessionRequestValidator : AbstractValidator<UpdatetSessionRequest>
{
    public UpdatetSessionRequestValidator()
    {
        RuleFor(x => x.SessionId)
            .NotEmpty().WithMessage("SessionId is required.");
    }
}
