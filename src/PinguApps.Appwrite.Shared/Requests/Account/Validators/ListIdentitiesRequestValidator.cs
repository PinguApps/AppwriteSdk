using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;
public class ListIdentitiesRequestValidator : AbstractValidator<ListIdentitiesRequest>
{
    public ListIdentitiesRequestValidator()
    {
        Include(new QueryBaseRequestValidator<ListIdentitiesRequest, ListIdentitiesRequestValidator>());
    }
}
