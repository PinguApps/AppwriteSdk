using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class DeleteTeamRequestValidator : AbstractValidator<DeleteTeamRequest>
{
    public DeleteTeamRequestValidator()
    {
        Include(new TeamIdBaseRequestValidator<DeleteTeamRequest, DeleteTeamRequestValidator>());
    }
}
