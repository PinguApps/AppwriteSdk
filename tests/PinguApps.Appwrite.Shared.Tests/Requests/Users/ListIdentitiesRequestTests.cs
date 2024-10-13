using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class ListIdentitiesRequestTests : QuerySearchBaseRequestTests<ListIdentitiesRequest, ListIdentitiesRequestValidator>
{
    protected override ListIdentitiesRequest CreateValidRequest => new();
}
