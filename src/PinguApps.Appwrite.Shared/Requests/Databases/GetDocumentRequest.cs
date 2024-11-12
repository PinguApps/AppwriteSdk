using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;
public class GetDocumentRequest : DatabaseCollectionDocumentIdBaseRequest<GetDocumentRequest, GetDocumentRequestValidator>
{
    /// <summary>
    /// Array of query strings generated using the Query class provided by the SDK. <see href="https://appwrite.io/docs/queries">Learn more about queries</see>. Maximum of 100 queries are allowed, each 4096 characters long.
    /// </summary>
    [JsonPropertyName("queries")]
    [SdkExclude]
    public List<Query>? Queries { get; set; } = null;
}
