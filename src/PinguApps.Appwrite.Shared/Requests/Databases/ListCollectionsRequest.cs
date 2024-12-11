using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to list collections in a database
/// </summary>
public class ListCollectionsRequest : QuerySearchBaseRequest<ListCollectionsRequest, ListCollectionsRequestValidator>
{
    /// <summary>
    /// Database ID
    /// </summary>
    [JsonPropertyName("databaseId")]
    [SdkExclude]
    public string DatabaseId { get; set; } = string.Empty;
}
