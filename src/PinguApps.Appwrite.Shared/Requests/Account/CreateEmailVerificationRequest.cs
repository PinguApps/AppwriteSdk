using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for creating an email verification (will email the user a link to verify their email)
/// </summary>
public class CreateEmailVerificationRequest : BaseRequest<CreateEmailVerificationRequest, CreateEmailVerificationRequestValidator>
{
    /// <summary>
    /// URL to redirect the user back to your app from the verification email. Only URLs from hostnames in your project platform list are allowed. This requirement helps to prevent an <see href="https://cheatsheetseries.owasp.org/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.html">open redirect</see> attack against your project API.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}
