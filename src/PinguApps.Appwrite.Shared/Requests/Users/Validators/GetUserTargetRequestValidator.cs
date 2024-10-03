using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class GetUserTargetRequestValidator : AbstractValidator<GetUserTargetRequest>
{
    public GetUserTargetRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<GetUserTargetRequest, GetUserTargetRequestValidator>());

        RuleFor(x => x.TargetId)
            .NotEmpty()
            .WithMessage("TargetId is required.");
    }
}
