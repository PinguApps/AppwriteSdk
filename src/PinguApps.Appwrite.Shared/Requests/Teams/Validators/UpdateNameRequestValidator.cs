using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class UpdateNameRequestValidator : AbstractValidator<UpdateNameRequest>
{
    public UpdateNameRequestValidator()
    {
        Include(new TeamIdBaseRequestValidator<UpdateNameRequest, UpdateNameRequestValidator>());

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(128)
            .WithMessage("Name must not exceed 128 characters.");
    }
}
