using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class TeamMembershipIdBaseRequestValidator<TRequest, TValidator> : AbstractValidator<TeamMembershipIdBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public TeamMembershipIdBaseRequestValidator()
    {
        Include(new TeamIdBaseRequestValidator<TRequest, TValidator>());

        RuleFor(x => x.MembershipId)
            .NotEmpty()
            .WithMessage("MembershipId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$")
            .WithMessage("MembershipId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special char. Max length is 36 chars.");
    }
}
