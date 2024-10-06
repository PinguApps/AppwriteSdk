using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("UserId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$")
            .WithMessage("UserId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special char. Max length is 36 chars.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email must either be null or not empty.")
            .EmailAddress()
            .When(x => x.Email is not null)
            .WithMessage("Invalid email format.");

        RuleFor(request => request.Phone)
            .Matches(@"^\+\d{1,15}$")
            .When(x => x.Phone is not null)
            .WithMessage("Phone number must be in the format +123456789.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .When(x => x.Password is not null)
            .WithMessage("Password must either be null or not empty.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .When(x => x.Name is not null)
            .WithMessage("Name must not be an empty string.")
            .MaximumLength(128)
            .WithMessage("Name must be at most 128 characters long.");
    }
}
