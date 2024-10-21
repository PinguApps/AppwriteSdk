using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Responses;
public record AttributesList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("attributes"), JsonConverter(typeof(AttributeListJsonConverter))] IReadOnlyList<Attribute> Attributes
);
