using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateSessionRequestTests : UserIdBaseRequestTests<CreateSessionRequest, CreateSessionRequestValidator>
{
    protected override CreateSessionRequest CreateValidRequest => new();
}
