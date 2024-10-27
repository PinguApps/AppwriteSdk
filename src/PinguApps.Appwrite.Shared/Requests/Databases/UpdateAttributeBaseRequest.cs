using System.Text.Json.Serialization;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The base request plus everything required to update an attribute (minus attribute specific properties)
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class UpdateAttributeBaseRequest<TRequest, TValidator> : DatabaseCollectionIdAttributeKeyBaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Is attribute required?
    /// </summary>
    [JsonPropertyName("required")]
    public bool Required { get; set; }

    /// <summary>
    /// New attribute key
    /// </summary>
    [JsonPropertyName("newKey")]
    public string? NewKey { get; set; }
}
