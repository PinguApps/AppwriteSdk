using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request to create a phone token
/// </summary>
public class CreatePhoneTokenRequest : BaseRequest<CreatePhoneTokenRequest, CreatePhoneTokenRequestValidator>
{
    /// <summary>
    /// Unique Id. Choose a custom ID or generate a random ID with <see cref="Utils.IdUtils.GenerateUniqueId(int)"/>. Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars.
    /// </summary>
    [JsonPropertyName("userId")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Phone number. Format this number with a leading '+' and a country code, e.g., +16175551212
    /// </summary>
    [JsonPropertyName("phone")]
    public string PhoneNumber { get; set; } = string.Empty;
}
