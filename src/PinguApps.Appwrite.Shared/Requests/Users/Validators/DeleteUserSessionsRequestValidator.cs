using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class DeleteUserSessionsRequestValidator : AbstractValidator<DeleteUserSessionsRequest>
{
    public DeleteUserSessionsRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<DeleteUserSessionsRequest, DeleteUserSessionsRequestValidator>());
    }
}
