using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for listing a user's targets
/// </summary>
public class ListUserTargetsRequest : UserIdBaseRequest<ListUserTargetsRequest, ListUserTargetsRequestValidator>
{
    /// <summary>
    /// Array of query strings generated using the Query class provided by the SDK. <see href="https://appwrite.io/docs/queries">Learn more about queries</see>. Maximum of 100 queries are allowed, each 4096 characters long. You may filter by the following attributes: <c>name</c>, <c>email</c>, <c>phone</c>, <c>status</c>, <c>passwordUpdate</c>, <c>registration</c>, <c>emailVerification</c>, <c>phoneVerification</c>, <c>labels</c>
    /// </summary>
    [JsonPropertyName("queries")]
    public virtual List<Query>? Queries { get; set; } = null;
}
