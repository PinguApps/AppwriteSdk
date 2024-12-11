using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class ListCollectionsRequestValidator : AbstractValidator<ListCollectionsRequest>
{
    public ListCollectionsRequestValidator()
    {
        Include(new QuerySearchBaseRequestValidator<ListCollectionsRequest, ListCollectionsRequestValidator>());

        RuleFor(x => x.DatabaseId)
            .NotEmpty()
            .WithMessage("DatabaseId is required.");
    }
}
