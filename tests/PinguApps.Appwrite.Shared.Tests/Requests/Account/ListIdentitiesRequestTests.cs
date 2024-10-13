using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class ListIdentitiesRequestTests : QueryBaseRequestTests<ListIdentitiesRequest, ListIdentitiesRequestValidator>
{
    protected override ListIdentitiesRequest CreateValidRequest => new();
}
