using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class CreateMfaRecoveryCodesRequestTests : UserIdBaseRequestTests<CreateMfaRecoveryCodesRequest, CreateMfaRecoveryCodesRequestValidator>
{
    protected override CreateMfaRecoveryCodesRequest CreateValidRequest => new();
}
