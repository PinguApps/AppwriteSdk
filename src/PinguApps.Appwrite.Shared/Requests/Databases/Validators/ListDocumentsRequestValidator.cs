using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class ListDocumentsRequestValidator : AbstractValidator<ListDocumentsRequest>
{
    public ListDocumentsRequestValidator()
    {
        Include(new QueryBaseRequestValidator<ListDocumentsRequest, ListDocumentsRequestValidator>());

        RuleFor(x => x.DatabaseId)
            .NotEmpty()
            .WithMessage("DatabaseId is required.");

        RuleFor(x => x.CollectionId)
            .NotEmpty()
            .WithMessage("CollectionId is required.");
    }
}
