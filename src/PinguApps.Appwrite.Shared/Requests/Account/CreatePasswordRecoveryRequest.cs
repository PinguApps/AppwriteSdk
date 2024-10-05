using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for creating a password recovery
/// </summary>
public class CreatePasswordRecoveryRequest : BaseRequest<CreatePasswordRecoveryRequest, CreatePasswordRecoveryRequestValidator>
{
    /// <summary>
    /// User email
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// URL to redirect the user back to your app from the recovery email. Only URLs from hostnames in your project platform list are allowed. This requirement helps to prevent an <see href="https://cheatsheetseries.owasp.org/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.html">open redirect</see> attack against your project API
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}
