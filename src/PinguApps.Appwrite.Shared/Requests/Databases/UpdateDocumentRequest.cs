using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to update a document. Can only be created with <see cref="CreateBuilder"/>
/// </summary>
public class UpdateDocumentRequest : DatabaseCollectionDocumentIdBaseRequest<UpdateDocumentRequest, UpdateDocumentRequestValidator>
{
    internal UpdateDocumentRequest() { }

    /// <summary>
    /// Document data. Include only attribute and value pairs to be updated. Build this up using <see cref="CreateBuilder"/>
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?> Data { get; set; } = [];

    /// <summary>
    /// An array of permissions strings. By default, the current permissions are inherited. <see href="https://appwrite.io/docs/permissions">Learn more about permissions</see>.
    /// </summary>
    [JsonPropertyName("permissions")]
    [JsonConverter(typeof(PermissionListConverter))]
    public List<Permission> Permissions { get; set; } = [];

    /// <summary>
    /// Creates a new builder for creating a document request
    /// </summary>
    public static IUpdateDocumentRequestBuilder CreateBuilder() => new UpdateDocumentRequestBuilder();
}
