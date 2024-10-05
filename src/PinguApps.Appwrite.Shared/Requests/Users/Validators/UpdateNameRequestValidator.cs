using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UpdateNameRequestValidator : AbstractValidator<UpdateNameRequest>
{
    public UpdateNameRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<UpdateNameRequest, UpdateNameRequestValidator>());

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(128)
            .WithMessage("Name must be at most 128 characters long.");
    }
}
