using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request for creating a collection
/// </summary>
public class CreateCollectionRequest : DatabaseIdBaseRequest<CreateCollectionRequest, CreateCollectionRequestValidator>
{
    /// <summary>
    /// Unique Id. Choose a custom ID or generate a random ID with ID.unique(). Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars
    /// </summary>
    [JsonPropertyName("collectionId")]
    public string CollectionId { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// Collection name. Max length: 128 chars
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// An array of permissions strings. By default, no user is granted with any permissions. <see href="https://appwrite.io/docs/permissions">Learn more about permissions</see>.
    /// </summary>
    [JsonPropertyName("permissions")]
    [JsonConverter(typeof(PermissionListConverter))]
    public List<Permission> Permissions { get; set; } = [];

    /// <summary>
    /// Enables configuring permissions for individual documents. A user needs one of document or collection level permissions to access a document. <see href="https://appwrite.io/docs/permissions">Learn more about permissions</see>.
    /// </summary>
    [JsonPropertyName("documentSecurity")]
    public bool DocumentSecurity { get; set; }

    /// <summary>
    /// Is collection enabled? When set to 'disabled', users cannot access the collection but Server SDKs with and API key can still read and write to the collection. No data is lost when this is toggled.
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; } = true;
}
