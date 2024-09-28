using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class ListUsersRequestTests : QuerySearchBaseRequestTests<ListUsersRequest, ListUsersRequestValidator>
{
    protected override ListUsersRequest CreateValidRequest => new();
}
