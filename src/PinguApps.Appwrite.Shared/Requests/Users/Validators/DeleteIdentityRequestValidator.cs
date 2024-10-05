using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class DeleteIdentityRequestValidator : AbstractValidator<DeleteIdentityRequest>
{
    public DeleteIdentityRequestValidator()
    {
        RuleFor(x => x.IdentityId)
            .NotEmpty()
            .WithMessage("IdentityId is required.");
    }
}
