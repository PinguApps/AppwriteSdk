using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for creating a target for a user
/// </summary>
public class CreateUserTargetRequest : UserIdBaseRequest<CreateUserTargetRequest, CreateUserTargetRequestValidator>
{
    /// <summary>
    /// Target ID. Choose a custom ID or generate a random ID with ID.unique(). Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.
    /// </summary>
    [JsonPropertyName("targetId")]
    public string TargetId { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// The target provider type. Can be one of the following: <see cref="TargetProviderType.Email"/>, <see cref="TargetProviderType.Sms"/>, <see cref="TargetProviderType.Push"/>
    /// </summary>
    [JsonPropertyName("providerType")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TargetProviderType ProviderType { get; set; }

    /// <summary>
    /// The target identifier (token, email, phone etc.)
    /// </summary>
    [JsonPropertyName("identifier")]
    public string Identifier { get; set; } = string.Empty;

    /// <summary>
    /// Provider ID. Message will be sent to this target from the specified provider ID. If no provider ID is set the first setup provider will be used.
    /// </summary>
    [JsonPropertyName("providerId")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ProviderId { get; set; }

    /// <summary>
    /// Target name. Max length: 128 chars. For example: My Awesome App Galaxy S23
    /// </summary>
    [JsonPropertyName("name")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Name { get; set; }
}
