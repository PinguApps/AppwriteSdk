using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to create a boolean attribute
/// </summary>
public class CreateBooleanAttributeRequest : CreateAttributeBaseRequest<CreateBooleanAttributeRequest, CreateBooleanAttributeRequestValidator>
{
    /// <summary>
    /// Default value for attribute when not provided. Cannot be set when attribute is required
    /// </summary>
    [JsonPropertyName("default")]
    public bool? Default { get; set; }
}
