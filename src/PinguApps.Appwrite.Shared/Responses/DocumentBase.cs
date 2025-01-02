using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Document object
/// </summary>
/// <param name="Id">Document ID</param>
/// <param name="CollectionId">Collection ID</param>
/// <param name="DatabaseId">Database ID</param>
/// <param name="CreatedAt">Document creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Document update date in ISO 8601 format</param>
/// <param name="Permissions">Document permissions. <see href="https://appwrite.io/docs/permissions">Learn more about permissions</see></param>
[JsonConverter(typeof(DocumentConverter))]
public abstract record DocumentBase(
    [property: JsonPropertyName("$id")] string? Id,
    [property: JsonPropertyName("$collectionId")] string? CollectionId,
    [property: JsonPropertyName("$databaseId")] string? DatabaseId,
    [property: JsonPropertyName("$createdAt"), JsonConverter(typeof(NullableDateTimeConverter))] DateTime? CreatedAt,
    [property: JsonPropertyName("$updatedAt"), JsonConverter(typeof(NullableDateTimeConverter))] DateTime? UpdatedAt,
    [property: JsonPropertyName("$permissions"), JsonConverter(typeof(PermissionReadOnlyListConverter))] IReadOnlyList<Permission>? Permissions
);
