using System.Text.Json.Serialization;
using FluentValidation;
using PinguApps.Appwrite.Shared.Attributes;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The base request but also containing DatabaseId and CollectionId
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class DatabaseCollectionIdBaseRequest<TRequest, TValidator> : DatabaseIdBaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Collection ID
    /// </summary>
    [JsonPropertyName("collectionId")]
    [SdkExclude]
    public string CollectionId { get; set; } = string.Empty;
}
