using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to update a float attribute
/// </summary>
public class UpdateFloatAttributeRequest : UpdateAttributeBaseRequest<UpdateFloatAttributeRequest, UpdateFloatAttributeRequestValidator>
{
    /// <summary>
    /// Default value for attribute when not provided. Cannot be set when attribute is required
    /// </summary>
    [JsonPropertyName("default")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float? Default { get; set; }

    /// <summary>
    /// Minimum value to enforce on new documents
    /// </summary>
    [JsonPropertyName("min")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float? Min { get; set; }

    /// <summary>
    /// Maximum value to enforce on new documents
    /// </summary>
    [JsonPropertyName("max")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public float? Max { get; set; }
}
