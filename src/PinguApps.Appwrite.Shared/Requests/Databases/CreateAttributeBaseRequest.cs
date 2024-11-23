using System.Text.Json.Serialization;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The base request plus everything required to create an attribute (minus attribute specific properties)
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class CreateAttributeBaseRequest<TRequest, TValidator> : DatabaseCollectionIdBaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Attribute Key
    /// </summary>
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;

    /// <summary>
    /// Is attribute required?
    /// </summary>
    [JsonPropertyName("required")]
    public bool Required { get; set; }

    /// <summary>
    /// Is attribute an array?
    /// </summary>
    [JsonPropertyName("array")]
    public bool Array { get; set; }
}
