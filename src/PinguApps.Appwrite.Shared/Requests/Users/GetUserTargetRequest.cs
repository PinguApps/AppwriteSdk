using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class GetUserTargetRequest : UserIdBaseRequest<GetUserTargetRequest, GetUserTargetRequestValidator>
{
    /// <summary>
    /// Target ID
    /// </summary>
    [JsonPropertyName("targetId")]
    public string TargetId { get; set; } = string.Empty;
}
