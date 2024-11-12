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
    /// 
    /// </summary>
    [JsonPropertyName("documentId")]
    public string DocumentId { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("data")]
    public TData Data { get; set; } = default!;

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("permissions")]
    [JsonConverter(typeof(PermissionListConverter))]
    public List<Permission> Permissions { get; set; } = [];
}
