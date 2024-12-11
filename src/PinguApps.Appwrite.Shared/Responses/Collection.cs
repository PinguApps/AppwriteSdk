using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Collection object
/// </summary>
/// <param name="Id">Collection ID</param>
/// <param name="CreatedAt">Collection creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Collection update date in ISO 8601 format</param>
/// <param name="Permissions">Collection permissions. <see href="https://appwrite.io/docs/permissions">Learn more about permissions</see></param>
/// <param name="DatabaseId">Database ID</param>
/// <param name="Name">Collection name</param>
/// <param name="Enabled">Collection enabled. Can be 'enabled' or 'disabled'. When disabled, the collection is inaccessible to users, but remains accessible to Server SDKs using API keys</param>
/// <param name="DocumentSecurity">Whether document-level permissions are enabled. <see href="https://appwrite.io/docs/permissions">Learn more about permissions</see></param>
/// <param name="Attributes">Collection attributes. Can be one of: <see cref="AttributeBoolean"/>, <see cref="AttributeDatetime"/>, <see cref="AttributeEmail"/>, <see cref="AttributeEnum"/>, <see cref="AttributeFloat"/>, <see cref="AttributeInteger"/>, <see cref="AttributeIp"/>, <see cref="AttributeRelationship"/>, <see cref="AttributeString"/>, <see cref="AttributeUrl"/></param>
/// <param name="Indexes">Collection indexes</param>
public record Collection(
    [property: JsonPropertyName("$id")] string Id,
    [property: JsonPropertyName("$createdAt"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime CreatedAt,
    [property: JsonPropertyName("$updatedAt"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime UpdatedAt,
    [property: JsonPropertyName("$permissions"), JsonConverter(typeof(PermissionReadOnlyListConverter))] IReadOnlyList<Permission> Permissions,
    [property: JsonPropertyName("databaseId")] string DatabaseId,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("enabled")] bool Enabled,
    [property: JsonPropertyName("documentSecurity")] bool DocumentSecurity,
    [property: JsonPropertyName("attributes"), JsonConverter(typeof(AttributeListJsonConverter))] IReadOnlyList<Attribute> Attributes,
    [property: JsonPropertyName("indexes")] IReadOnlyList<Index> Indexes
);
