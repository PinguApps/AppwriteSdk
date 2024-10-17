using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class DeleteTeamRequestTests : TeamIdBaseRequestTests<DeleteTeamRequest, DeleteTeamRequestValidator>
{
    protected override DeleteTeamRequest CreateValidRequest => new();
}
