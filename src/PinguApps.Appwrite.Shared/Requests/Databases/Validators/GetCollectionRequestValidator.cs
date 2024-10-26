using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class GetCollectionRequestValidator : AbstractValidator<GetCollectionRequest>
{
    public GetCollectionRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<GetCollectionRequest, GetCollectionRequestValidator>());
    }
}
