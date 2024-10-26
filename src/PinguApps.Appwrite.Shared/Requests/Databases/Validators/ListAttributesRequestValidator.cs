using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class ListAttributesRequestValidator : AbstractValidator<ListAttributesRequest>
{
    public ListAttributesRequestValidator()
    {
        Include(new QueryBaseRequestValidator<ListAttributesRequest, ListAttributesRequestValidator>());

        RuleFor(x => x.DatabaseId)
            .NotEmpty()
            .WithMessage("DatabaseId is required.");

        RuleFor(x => x.CollectionId)
            .NotEmpty()
            .WithMessage("CollectionId is required.");
    }
}
