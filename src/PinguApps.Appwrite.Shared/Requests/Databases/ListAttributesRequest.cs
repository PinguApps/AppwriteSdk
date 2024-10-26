using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to list attributes of a collection
/// </summary>
public class ListAttributesRequest : QueryBaseRequest<ListAttributesRequest, ListAttributesRequestValidator>
{
    /// <summary>
    /// Database ID
    /// </summary>
    [JsonPropertyName("databaseId")]
    [SdkExclude]
    public string DatabaseId { get; set; } = string.Empty;

    /// <summary>
    /// Collection ID
    /// </summary>
    [JsonPropertyName("databaseId")]
    [SdkExclude]
    public string CollectionId { get; set; } = string.Empty;
}
