using System.Text.Json.Serialization;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The base request but also containing queries and search
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class QuerySearchBaseRequest<TRequest, TValidator> : QueryBaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Search term to filter your list results. Max length: 256 chars
    /// </summary>
    [JsonPropertyName("search")]
    public string? Search { get; set; }
}
