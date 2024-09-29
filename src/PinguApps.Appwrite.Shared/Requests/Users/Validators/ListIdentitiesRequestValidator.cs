using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class ListIdentitiesRequestValidator : AbstractValidator<ListIdentitiesRequest>
{
    public ListIdentitiesRequestValidator()
    {
        Include(new QuerySearchBaseRequestValidator<ListIdentitiesRequest, ListIdentitiesRequestValidator>());
    }
}
