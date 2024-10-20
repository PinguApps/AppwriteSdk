using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Teams.Validators;
public class ListTeamsRequestValidator : AbstractValidator<ListTeamsRequest>
{
    public ListTeamsRequestValidator()
    {
        Include(new QuerySearchBaseRequestValidator<ListTeamsRequest, ListTeamsRequestValidator>());
    }
}
