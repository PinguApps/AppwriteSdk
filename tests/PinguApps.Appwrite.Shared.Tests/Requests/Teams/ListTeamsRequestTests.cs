using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class ListTeamsRequestTests : QuerySearchBaseRequestTests<ListTeamsRequest, ListTeamsRequestValidator>
{
    protected override ListTeamsRequest CreateValidRequest => new();
}
