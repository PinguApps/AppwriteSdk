using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class GetUserRequestValidator : AbstractValidator<GetUserRequest>
{
    public GetUserRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<GetUserRequest, GetUserRequestValidator>());
    }
}
