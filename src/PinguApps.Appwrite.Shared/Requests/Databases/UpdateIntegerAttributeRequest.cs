using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;
public class UpdateIntegerAttributeRequest : UpdateAttributeBaseRequest<UpdateIntegerAttributeRequest, UpdateIntegerAttributeRequestValidator>
{
    /// <summary>
    /// Default value for attribute when not provided. Cannot be set when attribute is required
    /// </summary>
    [JsonPropertyName("default")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Default { get; set; }

    /// <summary>
    /// Minimum value to enforce on new documents
    /// </summary>
    [JsonPropertyName("min")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Min { get; set; }

    /// <summary>
    /// Maximum value to enforce on new documents
    /// </summary>
    [JsonPropertyName("max")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int? Max { get; set; }
}
