﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite DocumentsList attribute
/// </summary>
/// <param name="Total">Total number of documents documents that matched your query</param>
/// <param name="Documents">List of documents</param>
public record DocumentsList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("documents"), JsonConverter(typeof(DocumentListConverter))] IReadOnlyList<Document> Documents
);