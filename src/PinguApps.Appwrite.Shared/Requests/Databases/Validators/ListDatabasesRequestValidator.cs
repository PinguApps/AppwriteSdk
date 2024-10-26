using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class ListDatabasesRequestValidator : AbstractValidator<ListDatabasesRequest>
{
    public ListDatabasesRequestValidator()
    {
        Include(new QuerySearchBaseRequestValidator<ListDatabasesRequest, ListDatabasesRequestValidator>());
    }
}
