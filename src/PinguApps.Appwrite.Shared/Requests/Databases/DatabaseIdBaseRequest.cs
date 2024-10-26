using System.Text.Json.Serialization;
using FluentValidation;
using PinguApps.Appwrite.Shared.Attributes;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The base request but also containing DatabaseId
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class DatabaseIdBaseRequest<TRequest, TValidator> : BaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Database ID
    /// </summary>
    [JsonPropertyName("databaseId")]
    [SdkExclude]
    public string DatabaseId { get; set; } = string.Empty;
}
