using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
{
    public CreateTokenRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<CreateTokenRequest, CreateTokenRequestValidator>());

        RuleFor(x => x.Length)
            .GreaterThan(0)
            .WithMessage("Token length must be greater than 0.")
            .When(x => x.Length.HasValue);

        RuleFor(x => x.Expire)
            .GreaterThan(0)
            .WithMessage("Token expiration must be greater than 0 seconds.")
            .When(x => x.Expire.HasValue);
    }
}
