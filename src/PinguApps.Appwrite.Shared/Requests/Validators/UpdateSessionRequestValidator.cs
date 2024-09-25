using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;

/// <summary>
/// Validator for <see cref="UpdateSessionRequest"/>
/// </summary>
public class UpdateSessionRequestValidator : AbstractValidator<UpdateSessionRequest>
{
    public UpdateSessionRequestValidator()
    {
        RuleFor(x => x.SessionId)
            .NotEmpty().WithMessage("SessionId is required.");
    }
}
