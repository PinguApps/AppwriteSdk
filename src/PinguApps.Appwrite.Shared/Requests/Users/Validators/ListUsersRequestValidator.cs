using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class ListUsersRequestValidator : AbstractValidator<ListUsersRequest>
{
    public ListUsersRequestValidator()
    {
        Include(new QuerySearchBaseRequestValidator<ListUsersRequest, ListUsersRequestValidator>());
    }
}
