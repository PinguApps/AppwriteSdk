using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class UpdateUserTargertRequest : UserIdBaseRequest<UpdateUserTargertRequest, UpdateUserTargertRequestValidator>
{
    /// <summary>
    /// Target ID
    /// </summary>
    [JsonPropertyName("targetId")]
    public string TargetId { get; set; } = string.Empty;

    /// <summary>
    /// The target identifier (token, email, phone etc.)
    /// </summary>
    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    /// <summary>
    /// Provider ID. Message will be sent to this target from the specified provider ID. If no provider ID is set the first setup provider will be used
    /// </summary>
    [JsonPropertyName("providerId")]
    public string? ProviderId { get; set; }

    /// <summary>
    /// Target name. Max length: 128 chars. For example: My Awesome App Galaxy S23.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
