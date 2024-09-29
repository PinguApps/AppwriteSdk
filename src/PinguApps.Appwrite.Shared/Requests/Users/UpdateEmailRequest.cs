using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class UpdateEmailRequest : UserIdBaseRequest<UpdateEmailRequest, UpdateEmailRequestValidator>
{
    /// <summary>
    /// User email
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;
}
