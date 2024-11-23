using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class UpdateRelationshipAttributeRequestValidator : AbstractValidator<UpdateRelationshipAttributeRequest>
{
    public UpdateRelationshipAttributeRequestValidator()
    {
        Include(new DatabaseCollectionIdAttributeKeyBaseRequestValidator<UpdateRelationshipAttributeRequest, UpdateRelationshipAttributeRequestValidator>());

        RuleFor(x => x.NewKey)
            .NotEmpty()
            .When(x => x.NewKey is not null)
            .WithMessage("NewKey must either be null or a non empty string");

        RuleFor(x => x.OnDelete)
            .IsInEnum()
            .When(x => x.OnDelete is not null)
            .WithMessage("OnDelete must be a valid OnDelete value.");
    }
}
