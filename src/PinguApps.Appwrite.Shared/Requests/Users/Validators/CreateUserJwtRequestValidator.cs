using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserJwtRequestValidator : AbstractValidator<CreateUserJwtRequest>
{
    public CreateUserJwtRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<CreateUserJwtRequest, CreateUserJwtRequestValidator>());

        RuleFor(x => x.SessionId)
            .NotEmpty()
            .When(x => x.SessionId is not null)
            .WithMessage("Session ID must be null or a non-empty string.");

        RuleFor(x => x.Duration)
            .GreaterThanOrEqualTo(0).WithMessage("Duration must be at least 0 seconds.")
            .LessThanOrEqualTo(3600).WithMessage("Duration must be at most 3600 seconds.")
            .When(x => x.Duration.HasValue);
    }
}
