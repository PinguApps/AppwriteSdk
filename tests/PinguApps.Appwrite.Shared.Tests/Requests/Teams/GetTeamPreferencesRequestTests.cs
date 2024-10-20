using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class GetTeamPreferencesRequestTests : TeamIdBaseRequestTests<GetTeamPreferencesRequest, GetTeamPreferencesRequestValidator>
{
    protected override GetTeamPreferencesRequest CreateValidRequest => new();
}
