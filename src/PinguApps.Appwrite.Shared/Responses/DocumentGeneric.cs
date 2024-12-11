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
/// <param name="Data">Document data</param>
[JsonConverter(typeof(DocumentGenericConverterFactory))]
public record Document<TData>(
    string Id,
    string CollectionId,
    string DatabaseId,
    DateTime? CreatedAt,
    DateTime? UpdatedAt,
    IReadOnlyList<Permission> Permissions,
    TData Data
) : DocumentBase(Id, CollectionId, DatabaseId, CreatedAt, UpdatedAt, Permissions)
    where TData : class, new();
