using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to create a realtionship attribute
/// </summary>
public class CreateRelationshipAttributeRequest : DatabaseCollectionIdBaseRequest<CreateRelationshipAttributeRequest, CreateRelationshipAttributeRequestValidator>
{
    /// <summary>
    /// Related Collection ID. You can create a new collection using the Database service <see href="https://appwrite.io/docs/server/databases#databasesCreateCollection">server integration</see>.
    /// </summary>
    [JsonPropertyName("relatedCollectionId")]
    public string RelatedCollectionId { get; set; } = string.Empty;

    /// <summary>
    /// Relation type
    /// </summary>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(CamelCaseEnumConverter))]
    public RelationType Type { get; set; }

    /// <summary>
    /// Is Two Way?
    /// </summary>
    [JsonPropertyName("twoWay")]
    public bool TwoWay { get; set; }

    /// <summary>
    /// Attribute Key
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Two Way Attribute Key
    /// </summary>
    [JsonPropertyName("twoWayKey")]
    public string TwoWayKey { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// Constraints option
    /// </summary>
    [JsonPropertyName("onDelete")]
    [JsonConverter(typeof(CamelCaseEnumConverter))]
    public OnDelete OnDelete { get; set; }
}
