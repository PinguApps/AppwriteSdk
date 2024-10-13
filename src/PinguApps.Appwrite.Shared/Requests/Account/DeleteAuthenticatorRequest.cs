using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for deleting an authenticator
/// </summary>
public class DeleteAuthenticatorRequest : BaseRequest<DeleteAuthenticatorRequest, DeleteAuthenticatorRequestValidator>
{
    /// <summary>
    /// Type of authenticator
    /// </summary>
    [JsonPropertyName("type")]
    [SdkExclude]
    public string Type { get; set; } = "totp";

    /// <summary>
    /// Valid verification token
    /// </summary>
    [JsonPropertyName("otp")]
    public string Otp { get; set; } = string.Empty;
}
