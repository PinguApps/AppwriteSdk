using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<DeleteUserRequest, DeleteUserRequestValidator>());
    }
}
