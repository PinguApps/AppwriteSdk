using System.Text.Json.Serialization;
using FluentValidation;
using PinguApps.Appwrite.Shared.Attributes;

namespace PinguApps.Appwrite.Shared.Requests.Teams;

/// <summary>
/// The base request but also containing TeamId and MembershipId
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TValidator"></typeparam>
public abstract class TeamMembershipIdBaseRequest<TRequest, TValidator> : TeamIdBaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// Membership ID. Choose a custom ID or generate a random ID with <see cref="Utils.IdUtils.GenerateUniqueId(int)"/>. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.
    /// </summary>
    [JsonPropertyName("teamId")]
    [SdkExclude]
    public string MembershipId { get; set; } = string.Empty;
}
