using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to list documents
/// </summary>
public class ListDocumentsRequest : QueryBaseRequest<ListDocumentsRequest, ListDocumentsRequestValidator>
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
