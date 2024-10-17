using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class UpdateMembershipRequestValidator : AbstractValidator<UpdateMembershipRequest>
{
    public UpdateMembershipRequestValidator()
    {
        Include(new TeamMembershipIdBaseRequestValidator<UpdateMembershipRequest, UpdateMembershipRequestValidator>());

        RuleFor(x => x.Roles)
            .NotNull()
            .WithMessage("Roles cannot be null.")
            .Must(x => x.Count <= 100)
            .WithMessage("A maximum of 100 roles are allowed.")
            .ForEach(x => x
                .MaximumLength(32)
                .WithMessage("Each role can be a maximum of 32 characters long."));
    }
}
