using System.Collections.Generic;
using System.Text.Json.Serialization;
using FluentValidation;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The base request but also containing Queries
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class QueryBaseRequest<TRequest, TValidator> : BaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Array of query strings generated using the Query class provided by the SDK. <see href="https://appwrite.io/docs/queries">Learn more about queries</see>. Maximum of 100 queries are allowed, each 4096 characters long.
    /// </summary>
    [JsonPropertyName("queries")]
    public virtual List<Query>? Queries { get; set; } = null;
}
