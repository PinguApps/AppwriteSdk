using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class GetMfaRecoveryCodesRequestTests : UserIdBaseRequestTests<GetMfaRecoveryCodesRequest, GetMfaRecoveryCodesRequestValidator>
{
    protected override GetMfaRecoveryCodesRequest CreateValidRequest => new();
}
