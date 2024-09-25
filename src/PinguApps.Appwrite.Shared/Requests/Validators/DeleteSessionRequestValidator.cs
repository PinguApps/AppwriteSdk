using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;

/// <summary>
/// Validator for <see cref="DeleteSessionRequest"/>
/// </summary>
public class DeleteSessionRequestValidator : AbstractValidator<DeleteSessionRequest>
{
    public DeleteSessionRequestValidator()
    {
        RuleFor(x => x.SessionId)
            .NotEmpty().WithMessage("SessionId is required.");
    }
}
