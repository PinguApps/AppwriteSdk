using System.Text.Json.Serialization;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Teams;

/// <summary>
/// The base request but also containing TeamId
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class TeamIdBaseRequest<TRequest, TValidator> : BaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Team ID. Choose a custom ID or generate a random ID with <see cref="Utils.IdUtils.GenerateUniqueId(int)"/>. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.
    /// </summary>
    [JsonPropertyName("teamId")]
    public string TeamId { get; set; } = string.Empty;
}
