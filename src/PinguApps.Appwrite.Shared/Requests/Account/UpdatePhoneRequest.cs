using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for updating a users phone
/// </summary>
public class UpdatePhoneRequest : BaseRequest<UpdatePhoneRequest, UpdatePhoneRequestValidator>
{
    /// <summary>
    /// Phone number. Format this number with a leading '+' and a country code, e.g., +16175551212
    /// </summary>
    [JsonPropertyName("phone")]
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// New user password. Must be at least 8 chars
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;
}

