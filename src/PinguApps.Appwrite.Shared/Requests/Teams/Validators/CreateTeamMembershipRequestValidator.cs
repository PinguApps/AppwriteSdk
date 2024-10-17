using System;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class CreateTeamMembershipRequestValidator : AbstractValidator<CreateTeamMembershipRequest>
{
    public CreateTeamMembershipRequestValidator()
    {
        Include(new TeamIdBaseRequestValidator<CreateTeamMembershipRequest, CreateTeamMembershipRequestValidator>());

        RuleFor(x => x.Roles)
            .NotNull()
            .WithMessage("Roles cannot be null.")
            .Must(x => x.Count <= 100)
            .WithMessage("A maximum of 100 roles are allowed.")
            .ForEach(x => x.MaximumLength(32).WithMessage("Each role can be a maximum of 32 characters long."));

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email must either be null or a non empty string.")
            .EmailAddress()
            .When(x => x.Email is not null)
            .WithMessage("Invalid email format.");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone must either be null or a non empty string.")
            .Matches(@"^\+\d{1,15}$")
            .When(x => x.Phone is not null)
            .WithMessage("Phone number must be in the format +123456789.");

        RuleFor(x => x.Url)
            .NotEmpty()
            .WithMessage("Url must either be null or a non empty string.")
            .Must(x => Uri.TryCreate(x, UriKind.Absolute, out _))
            .When(x => x.Url is not null)
            .WithMessage("Invalid URL format.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name must either be null or a non empty string.")
            .MaximumLength(128)
            .When(x => x.Name is not null)
            .WithMessage("Name can be a maximum of 128 characters long.");

        RuleFor(x => x)
            .Must(x => !string.IsNullOrEmpty(x.UserId) || !string.IsNullOrEmpty(x.Email) || !string.IsNullOrEmpty(x.Phone))
            .WithMessage("At least one of UserId, Email, or Phone must be provided.");
    }
}
