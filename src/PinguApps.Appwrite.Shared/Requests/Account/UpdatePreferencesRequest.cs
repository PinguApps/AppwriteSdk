using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for updating a users preferences
/// </summary>
public class UpdatePreferencesRequest : BaseRequest<UpdatePreferencesRequest, UpdatePreferencesRequestValidator>
{
    /// <summary>
    /// New value for preferences
    /// </summary>
    [JsonPropertyName("prefs")]
    public IDictionary<string, string> Preferences { get; set; } = new Dictionary<string, string>();
}
