using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for creating a 2fa challenge
/// </summary>
public class Create2faChallengeRequest : BaseRequest<Create2faChallengeRequest, Create2faChallengeRequestValidator>
{
    /// <summary>
    /// Factor used for verification. Must be one of following: <list type="bullet">
    /// <item><description>email</description></item>
    /// <item><description>phone</description></item>
    /// <item><description>totp</description></item>
    /// <item><description>recoveryCode</description></item>
    /// </list>
    /// </summary>
    [JsonPropertyName("factor")]
    [JsonConverter(typeof(CamelCaseEnumConverter))]
    public SecondFactor Factor { get; set; }
}
