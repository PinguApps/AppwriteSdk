using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserWithPhpassPasswordRequestValidator : AbstractValidator<CreateUserWithPhpassPasswordRequest>
{
    public CreateUserWithPhpassPasswordRequestValidator()
    {
        Include(new CreateUserWithPasswordBaseRequestValidator<CreateUserWithPhpassPasswordRequest, CreateUserWithPhpassPasswordRequestValidator>());
    }
}
