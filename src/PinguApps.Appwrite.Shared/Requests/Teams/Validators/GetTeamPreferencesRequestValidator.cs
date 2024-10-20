using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class GetTeamPreferencesRequestValidator : AbstractValidator<GetTeamPreferencesRequest>
{
    public GetTeamPreferencesRequestValidator()
    {
        Include(new TeamIdBaseRequestValidator<GetTeamPreferencesRequest, GetTeamPreferencesRequestValidator>());
    }
}
