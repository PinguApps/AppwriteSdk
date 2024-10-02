using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class GetUserPreferencesRequestTests : UserIdBaseRequestTests<GetUserPreferencesRequest, GetUserPreferencesRequestValidator>
{
    protected override GetUserPreferencesRequest CreateValidRequest => new();
}
