using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Requests.Teams;

/// <summary>
/// The request to update the preferences of a team
/// </summary>
public class UpdatePreferencesRequest : TeamIdBaseRequest<UpdatePreferencesRequest, UpdatePreferencesRequestValidator>
{
    /// <summary>
    /// Prefs key-value JSON object
    /// </summary>
    [JsonPropertyName("prefs")]
    public IDictionary<string, string> Preferences { get; set; } = new Dictionary<string, string>();
}
