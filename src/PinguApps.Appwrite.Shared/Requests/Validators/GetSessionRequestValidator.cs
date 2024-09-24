using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class GetSessionRequestValidator : AbstractValidator<GetSessionRequest>
{
    public GetSessionRequestValidator()
    {
        RuleFor(x => x.SessionId)
            .NotEmpty().WithMessage("SessionId is required.");
    }
}
