using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;

/// <summary>
/// Validator for <see cref="GetSessionRequest"/>
/// </summary>
public class GetSessionRequestValidator : AbstractValidator<GetSessionRequest>
{
    public GetSessionRequestValidator()
    {
        RuleFor(x => x.SessionId)
            .NotEmpty().WithMessage("SessionId is required.");
    }
}
