using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to create an index on a collection
/// </summary>
public class CreateIndexRequest : DatabaseCollectionIdBaseRequest<CreateIndexRequest, CreateIndexRequestValidator>
{
    /// <summary>
    /// Index Key
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Index type
    /// </summary>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(CamelCaseEnumConverter))]
    public IndexType IndexType { get; set; }

    /// <summary>
    /// Array of attributes (referenced via their Key) to index. Maximum of 100 attributes are allowed, each 32 characters long. Must match quantity of <see cref="Orders"/>
    /// </summary>
    [JsonPropertyName("attributes")]
    public List<string> Attributes { get; set; } = [];

    /// <summary>
    /// Array of index orders. Maximum of 100 orders are allowed. Must match quantity of <see cref="Attributes"/>
    /// </summary>
    [JsonPropertyName("orders")]
    [JsonConverter(typeof(UpperCaseEnumListConverter<SortDirection>))]
    public List<SortDirection> Orders { get; set; } = [];
}
