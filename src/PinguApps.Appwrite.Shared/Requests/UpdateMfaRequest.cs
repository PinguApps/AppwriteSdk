using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for updating Mfa
/// </summary>
public class UpdateMfaRequest : BaseRequest<UpdateMfaRequest, UpdateMfaRequestValidator>
{
    /// <summary>
    /// Enable or disable MFA
    /// </summary>
    [JsonPropertyName("mfa")]
    public bool MfaEnabled { get; set; }
}
