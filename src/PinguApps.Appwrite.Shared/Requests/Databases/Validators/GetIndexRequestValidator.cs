using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class GetIndexRequestValidator : AbstractValidator<GetIndexRequest>
{
    public GetIndexRequestValidator()
    {
        Include(new DatabaseCollectionIdIndexKeyBaseRequestValidator<GetIndexRequest, GetIndexRequestValidator>());
    }
}
