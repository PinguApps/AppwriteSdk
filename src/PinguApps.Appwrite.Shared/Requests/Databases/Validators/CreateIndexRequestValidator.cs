using System.Linq;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateIndexRequestValidator : AbstractValidator<CreateIndexRequest>
{
    public CreateIndexRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<CreateIndexRequest, CreateIndexRequestValidator>());

        RuleFor(x => x.Key)
            .NotEmpty()
            .WithMessage("Key is required");

        RuleFor(x => x.IndexType)
            .IsInEnum()
            .WithMessage("IndexType must be within the enums range");

        RuleFor(x => x.Attributes)
           .NotNull()
           .Must(x => x.Count <= 100)
            .WithMessage("Maximum of 100 attributes are allowed")
           .Must(x => x.All(attr => attr.Length <= 32))
            .WithMessage("Each attribute must be 32 characters or less");

        RuleFor(x => x.Orders)
           .NotNull()
           .Must(x => x.Count <= 100)
            .WithMessage("Maximum of 100 orders are allowed")
           .Must((model, orders) => orders.Count == model.Attributes.Count)
            .WithMessage("Number of orders must match number of attributes");
    }
}
