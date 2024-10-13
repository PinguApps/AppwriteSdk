using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateSessionRequestValidator : AbstractValidator<CreateSessionRequest>
{
    public CreateSessionRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<CreateSessionRequest, CreateSessionRequestValidator>());
    }
}
