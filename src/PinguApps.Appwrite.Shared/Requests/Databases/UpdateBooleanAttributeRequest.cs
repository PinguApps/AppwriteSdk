using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to update a boolean attribute
/// </summary>
public class UpdateBooleanAttributeRequest : UpdateAttributeBaseRequest<UpdateBooleanAttributeRequest, UpdateBooleanAttributeRequestValidator>
{
    /// <summary>
    /// Default value for attribute when not provided. Cannot be set when attribute is required
    /// </summary>
    [JsonPropertyName("default")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public bool? Default { get; set; }
}
