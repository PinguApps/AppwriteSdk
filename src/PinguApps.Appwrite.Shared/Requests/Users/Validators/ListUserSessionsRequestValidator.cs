using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class ListUserSessionsRequestValidator : AbstractValidator<ListUserSessionsRequest>
{
    public ListUserSessionsRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<ListUserSessionsRequest, ListUserSessionsRequestValidator>());
    }
}
