using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for adding an authenticator
/// </summary>
public class AddAuthenticatorRequest : BaseRequest<AddAuthenticatorRequest, AddAuthenticatorRequestValidator>
{
    /// <summary>
    /// Type of authenticator. Must be `totp`
    /// </summary>
    [JsonPropertyName("type")]
    [SdkExclude]
    public string Type { get; set; } = "totp";
}
