using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<CreateUserRequest, CreateUserRequestValidator>());

        RuleFor(request => request.Email)
            .EmailAddress()
            .When(x => x.Email is not null)
            .WithMessage("Invalid email format.");

        RuleFor(request => request.Phone)
            .Matches(@"^\+\d{1,15}$")
            .When(x => x.Phone is not null)
            .WithMessage("Phone number must be in the format +123456789.");

        RuleFor(request => request.Password)
            .MinimumLength(8)
            .When(x => x.Password is not null)
            .WithMessage("Password must be at least 8 characters long.");

        RuleFor(request => request.Name)
            .NotEmpty()
            .When(x => x.Name is not null)
            .WithMessage("Name must not be an empty string.")
            .MaximumLength(128)
            .When(x => x.Name is not null)
            .WithMessage("Name must not exceed 128 characters.");
    }
}
