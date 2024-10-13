using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class ListUserMembershipsRequestTests : UserIdBaseRequestTests<ListUserMembershipsRequest, ListUserMembershipsRequestValidator>
{
    protected override ListUserMembershipsRequest CreateValidRequest => new();
}
