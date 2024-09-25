using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for creating a 2fa challenge confirmation
/// </summary>
public class Create2faChallengeConfirmationRequest : BaseRequest<Create2faChallengeConfirmationRequest, Create2faChallengeConfirmationRequestValidator>
{
    /// <summary>
    /// ID of the challenge
    /// </summary>
    [JsonPropertyName("challengeId")]
    public string ChallengeId { get; set; } = string.Empty;

    /// <summary>
    /// Valid verification token
    /// </summary>
    [JsonPropertyName("otp")]
    public string Otp { get; set; } = string.Empty;
}
