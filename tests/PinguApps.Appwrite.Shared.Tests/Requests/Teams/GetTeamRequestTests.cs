using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class GetTeamRequestTests : TeamIdBaseRequestTests<GetTeamRequest, GetTeamRequestValidator>
{
    protected override GetTeamRequest CreateValidRequest => new();
}
