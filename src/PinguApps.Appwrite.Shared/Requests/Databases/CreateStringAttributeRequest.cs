using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to create a string attribute
/// </summary>
public class CreateStringAttributeRequest : CreateStringAttributeBaseRequest<CreateStringAttributeRequest, CreateStringAttributeRequestValidator>
{
    /// <summary>
    /// Attribute size for text attributes, in number of characters
    /// </summary>
    [JsonPropertyName("size")]
    public int Size { get; set; }

    /// <summary>
    /// Toggle encryption for the attribute. Encryption enhances security by not storing any plain text values in the database. However, encrypted attributes cannot be queried
    /// </summary>
    [JsonPropertyName("encrypt")]
    public bool Encrypt { get; set; }
}
