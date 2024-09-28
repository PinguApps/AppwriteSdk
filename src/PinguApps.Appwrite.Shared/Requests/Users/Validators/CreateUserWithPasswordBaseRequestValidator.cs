using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserWithPasswordBaseRequestValidator<TRequest, TValidator> : AbstractValidator<CreateUserWithPasswordBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public CreateUserWithPasswordBaseRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<TRequest, TValidator>());

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .When(x => x.Name is not null)
            .WithMessage("Name must not be an empty string.")
            .MaximumLength(128)
            .WithMessage("Name must be at most 128 characters long.");
    }
}
