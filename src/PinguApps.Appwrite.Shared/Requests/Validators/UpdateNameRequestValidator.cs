using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;

/// <summary>
/// Validator for <see cref="UpdateNameRequest"/>
/// </summary>
public class UpdateNameRequestValidator : AbstractValidator<UpdateNameRequest>
{
    public UpdateNameRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(128).WithMessage("Name can be at most 128 characters long.");
    }
}
