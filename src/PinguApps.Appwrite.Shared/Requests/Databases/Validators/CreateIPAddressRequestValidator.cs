using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateIPAddressRequestValidator : AbstractValidator<CreateIPAddressRequest>
{
    public CreateIPAddressRequestValidator()
    {
        Include(new CreateStringAttributeBaseRequestValidator<CreateIPAddressRequest, CreateIPAddressRequestValidator>());
    }
}
