using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for adding an authenticator
/// </summary>
public class AddAuthenticatorRequest : BaseRequest<AddAuthenticatorRequest, AddAuthenticatorRequestValidator>
{
    /// <summary>
    /// Type of authenticator. Must be `totp`
    /// </summary>
    [JsonIgnore]
    public string Type { get; set; } = "totp";
}
