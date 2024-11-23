using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Index object
/// </summary>
/// <param name="Key">Index Key</param>
/// <param name="Type">Index Type</param>
/// <param name="Status">Index status. Possible values: <c>available</c>, <c>processing</c>, <c>deleting</c>, <c>stuck</c>, or <c>failed</c></param>
/// <param name="Error">Error message. Displays error generated on failure of creating or deleting an index</param>
/// <param name="Attributes">Index attributes</param>
/// <param name="Orders">Index orders</param>
/// <param name="CreatedAt">Index creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Index update date in ISO 8601 format</param>
public record Index(
    [property: JsonPropertyName("key")] string Key,
    [property: JsonPropertyName("type"), JsonConverter(typeof(CamelCaseEnumConverter))] IndexType Type,
    [property: JsonPropertyName("status"), JsonConverter(typeof(CamelCaseEnumConverter))] DatabaseElementStatus Status,
    [property: JsonPropertyName("error")] string? Error,
    [property: JsonPropertyName("attributes")] IReadOnlyList<string> Attributes,
    [property: JsonPropertyName("orders")] IReadOnlyList<string> Orders,
    [property: JsonPropertyName("$createdAt"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime UpdatedAt
);
