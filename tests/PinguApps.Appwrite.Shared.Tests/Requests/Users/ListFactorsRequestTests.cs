using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class ListFactorsRequestTests : UserIdBaseRequestTests<ListFactorsRequest, ListFactorsRequestValidator>
{
    protected override ListFactorsRequest CreateValidRequest => new();
}
