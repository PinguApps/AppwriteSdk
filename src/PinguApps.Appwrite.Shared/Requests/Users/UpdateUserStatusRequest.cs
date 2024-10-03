using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class UpdateUserStatusRequest : UserIdBaseRequest<UpdateUserStatusRequest, UpdateUserStatusRequestValidator>
{
    /// <summary>
    /// User Status. To activate the user pass <c>true</c> and to block the user pass <c>false</c>.
    /// </summary>
    [JsonPropertyName("status")]
    public bool Status { get; set; }
}
