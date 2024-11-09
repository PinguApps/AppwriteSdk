using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class GetAttributeRequestValidator : AbstractValidator<GetAttributeRequest>
{
    public GetAttributeRequestValidator()
    {
        Include(new DatabaseCollectionIdAttributeKeyBaseRequestValidator<GetAttributeRequest, GetAttributeRequestValidator>());
    }
}
