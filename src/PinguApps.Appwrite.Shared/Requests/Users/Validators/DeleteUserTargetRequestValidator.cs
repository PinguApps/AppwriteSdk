using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class DeleteUserTargetRequestValidator : AbstractValidator<DeleteUserTargetRequest>
{
    public DeleteUserTargetRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<DeleteUserTargetRequest, DeleteUserTargetRequestValidator>());

        RuleFor(x => x.TargetId)
            .NotEmpty()
            .WithMessage("Target ID is required.");
    }
}
