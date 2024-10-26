using System.Text.Json.Serialization;
using FluentValidation;
using PinguApps.Appwrite.Shared.Attributes;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The base request but also containing DatabaseId, CollectionId and DocumentId
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class DatabaseCollectionDocumentIdBaseRequest<TRequest, TValidator> : DatabaseCollectionIdBaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Document ID
    /// </summary>
    [JsonPropertyName("documentId")]
    [SdkExclude]
    public string DocumentId { get; set; } = string.Empty;
}
