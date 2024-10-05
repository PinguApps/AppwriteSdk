using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for getting a user's target
/// </summary>
public class GetUserTargetRequest : UserIdBaseRequest<GetUserTargetRequest, GetUserTargetRequestValidator>
{
    /// <summary>
    /// Target ID
    /// </summary>
    [JsonPropertyName("targetId")]
    public string TargetId { get; set; } = string.Empty;
}
