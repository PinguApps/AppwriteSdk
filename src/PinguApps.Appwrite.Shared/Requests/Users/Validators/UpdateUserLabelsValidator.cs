using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class UpdateUserLabelsValidator : AbstractValidator<UpdateUserLabels>
{
    public UpdateUserLabelsValidator()
    {
        Include(new UserIdBaseRequestValidator<UpdateUserLabels, UpdateUserLabelsValidator>());

        RuleFor(x => x.Labels)
            .NotNull().WithMessage("Labels cannot be null.")
            .Must(labels => labels.Count <= 1000).WithMessage("A maximum of 1000 labels are allowed.")
            .ForEach(labelRule => labelRule
                .NotEmpty().WithMessage("Label cannot be empty.")
                .MaximumLength(36).WithMessage("Label must be at most 36 characters long.")
                .Matches("^[a-zA-Z0-9]*$").WithMessage("Label must be alphanumeric.")
            );
    }
}
