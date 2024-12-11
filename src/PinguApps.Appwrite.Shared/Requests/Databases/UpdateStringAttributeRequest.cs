using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to update a string attribute
/// </summary>
public class UpdateStringAttributeRequest : UpdateStringAttributeBaseRequest<UpdateStringAttributeRequest, UpdateStringAttributeRequestValidator>
{
    /// <summary>
    /// Attribute size for text attributes, in number of characters
    /// </summary>
    [JsonPropertyName("size")]
    public int? Size { get; set; }
}
