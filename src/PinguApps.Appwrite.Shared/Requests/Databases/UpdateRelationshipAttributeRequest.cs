using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to update a relationship attribute
/// </summary>
public class UpdateRelationshipAttributeRequest : DatabaseCollectionIdAttributeKeyBaseRequest<UpdateRelationshipAttributeRequest, UpdateRelationshipAttributeRequestValidator>
{
    /// <summary>
    /// New attribute key
    /// </summary>
    [JsonPropertyName("newKey")]
    public string? NewKey { get; set; }

    /// <summary>
    /// Constraints option
    /// </summary>
    [JsonPropertyName("onDelete")]
    public OnDelete? OnDelete { get; set; }
}
