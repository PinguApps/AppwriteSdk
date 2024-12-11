using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateRelationshipAttributeRequestValidator : AbstractValidator<CreateRelationshipAttributeRequest>
{
    public CreateRelationshipAttributeRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<CreateRelationshipAttributeRequest, CreateRelationshipAttributeRequestValidator>());

        RuleFor(x => x.RelatedCollectionId)
            .NotEmpty()
            .WithMessage("RelatedCollectionId is required.");

        RuleFor(x => x.Type)
            .IsInEnum()
            .WithMessage("Type must be a valid RelationType.");

        RuleFor(x => x.Key)
            .NotEmpty()
            .WithMessage("Key is required.");

        RuleFor(x => x.TwoWayKey)
            .NotEmpty()
            .WithMessage("TwoWayKey is required.");

        RuleFor(x => x.OnDelete)
            .IsInEnum()
            .WithMessage("OnDelete must be a valid OnDelete value.");
    }
}
