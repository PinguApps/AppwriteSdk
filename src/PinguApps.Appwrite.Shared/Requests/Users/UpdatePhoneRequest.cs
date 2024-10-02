using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class UpdatePhoneRequest : UserIdBaseRequest<UpdatePhoneRequest, UpdatePhoneRequestValidator>
{
    /// <summary>
    /// User phone number. Format this number with a leading '+' and a country code, e.g., +16175551212
    /// </summary>
    [JsonPropertyName("number")]
    public string PhoneNumber { get; set; } = string.Empty;
}
