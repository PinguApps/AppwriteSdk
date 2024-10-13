using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UserIdBaseRequestValidator<TRequest, TValidator> : AbstractValidator<UserIdBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public UserIdBaseRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$").WithMessage("UserId can only contain a-z, A-Z, 0-9, period, hyphen, and underscore, and can't start with a special char. Max length is 36 chars.");
    }
}
