using System.Text.Json.Serialization;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The base request for any string based attribute
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class CreateStringAttributeBaseRequest<TRequest, TValidator> : CreateAttributeBaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Default value for attribute when not provided. Cannot be set when attribute is required
    /// </summary>
    [JsonPropertyName("default")]
    public string? Default { get; set; }
}
