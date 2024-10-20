using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class GetTeamRequestValidator : AbstractValidator<GetTeamRequest>
{
    public GetTeamRequestValidator()
    {
        Include(new TeamIdBaseRequestValidator<GetTeamRequest, GetTeamRequestValidator>());
    }
}
