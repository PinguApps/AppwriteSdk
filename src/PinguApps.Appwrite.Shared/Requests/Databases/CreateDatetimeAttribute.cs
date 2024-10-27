using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;
public class CreateDatetimeAttribute : CreateAttributeBaseRequest<CreateDatetimeAttribute, CreateDatetimeAttributeValidator>
{
    /// <summary>
    /// Default value for the attribute in ISO 8601 format. Cannot be set when attribute is required
    /// </summary>
    [JsonPropertyName("default")]
    [JsonConverter(typeof(NullableDateTimeConverter))]
    public DateTime? Default { get; set; }
}
