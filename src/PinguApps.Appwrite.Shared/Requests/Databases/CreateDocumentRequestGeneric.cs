using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to create a new document
/// </summary>
/// <typeparam name="TData">The type of the document data</typeparam>
public class CreateDocumentRequest<TData> : DatabaseCollectionIdBaseRequest<CreateDocumentRequest<TData>, CreateDocumentRequestValidator<TData>>
    where TData : class
{
    /// <summary>
    /// Document ID. Choose a custom ID or generate a random ID with ID.unique(). Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars
    /// </summary>
    [JsonPropertyName("documentId")]
    public string DocumentId { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// Document data - Provide your own type to match your database schema, or build this up using <see cref="CreateDocumentRequest.CreateBuilder"/>
    /// </summary>
    [JsonPropertyName("data")]
    public TData Data { get; set; } = default!;

    /// <summary>
    /// An array of permissions strings. By default, only the current user is granted all permissions. <see href="https://appwrite.io/docs/permissions">Learn more about permissions</see>.
    /// </summary>
    [JsonPropertyName("permissions")]
    [JsonConverter(typeof(PermissionListConverter))]
    public List<Permission>? Permissions { get; set; }
}
