using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class ListUserLogsRequest : UserIdBaseRequest<ListUserLogsRequest, ListUserLogsRequestValidator>
{
    /// <summary>
    /// Array of query strings generated using the Query class provided by the SDK. <see href="https://appwrite.io/docs/queries">Learn more about queries</see>. Maximum of 100 queries are allowed, each 4096 characters long. Only supported methods are limit and offset
    /// </summary>
    [JsonPropertyName("queries")]
    public virtual List<Query>? Queries { get; set; } = null;
}
