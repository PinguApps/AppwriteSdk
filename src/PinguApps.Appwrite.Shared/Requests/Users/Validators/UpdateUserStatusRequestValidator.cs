using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UpdateUserStatusRequestValidator : AbstractValidator<UpdateUserStatusRequest>
{
    public UpdateUserStatusRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<UpdateUserStatusRequest, UpdateUserStatusRequestValidator>());

        RuleFor(x => x.Status)
            .NotNull()
            .WithMessage("Status is required.");
    }
}
