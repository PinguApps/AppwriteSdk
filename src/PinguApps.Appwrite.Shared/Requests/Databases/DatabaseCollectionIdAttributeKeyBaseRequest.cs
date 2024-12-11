using System.Text.Json.Serialization;
using FluentValidation;
using PinguApps.Appwrite.Shared.Attributes;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The base request but also containing DatabaseId, CollectionId and Key for attributes
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class DatabaseCollectionIdAttributeKeyBaseRequest<TRequest, TValidator> : DatabaseCollectionIdBaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Attribute Key
    /// </summary>
    [JsonPropertyName("key")]
    [SdkExclude]
    public string Key { get; set; } = string.Empty;
}
