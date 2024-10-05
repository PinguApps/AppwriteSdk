using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class RegenerateMfaRecoveryCodesRequestTests : UserIdBaseRequestTests<RegenerateMfaRecoveryCodesRequest, RegenerateMfaRecoveryCodesRequestValidator>
{
    protected override RegenerateMfaRecoveryCodesRequest CreateValidRequest => new();
}
