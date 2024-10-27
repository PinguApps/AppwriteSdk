using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;
public class UpdateDatetimeAttributeRequest : UpdateAttributeBaseRequest<UpdateDatetimeAttributeRequest, UpdateDatetimeAttributeRequestValidator>
{
    /// <summary>
    /// Default value for attribute when not provided. Cannot be set when attribute is required
    /// </summary>
    [JsonPropertyName("default")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    [JsonConverter(typeof(AlwaysWriteNullableDateTimeConverter))]
    public DateTime? Default { get; set; }
}
