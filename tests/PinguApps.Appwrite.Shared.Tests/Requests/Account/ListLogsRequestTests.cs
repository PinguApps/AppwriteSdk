using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Account;
public class ListLogsRequestTests : QueryBaseRequestTests<ListLogsRequest, ListLogsRequestValidator>
{
    protected override ListLogsRequest CreateValidRequest => new();
}
