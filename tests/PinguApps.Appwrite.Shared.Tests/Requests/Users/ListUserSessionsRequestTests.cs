using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class ListUserSessionsRequestTests : UserIdBaseRequestTests<ListUserSessionsRequest, ListUserSessionsRequestValidator>
{
    protected override ListUserSessionsRequest CreateValidRequest => new();
}
