using System.Text.Json.Serialization;
using FluentValidation;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The base request containing userId, email, password and name
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public class CreateUserWithPasswordBaseRequest<TRequest, TValidator> : BaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// User ID. Choose a custom ID or generate a random ID with <see cref="Utils.IdUtils.GenerateUniqueId(int)"/>. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// User Email
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// User password hashed
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// User name. Max length: 128 chars
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
