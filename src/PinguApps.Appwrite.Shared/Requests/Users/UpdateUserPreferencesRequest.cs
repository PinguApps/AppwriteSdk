using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class UpdateUserPreferencesRequest : UserIdBaseRequest<UpdateUserPreferencesRequest, UpdateUserPreferencesRequestValidator>
{
    /// <summary>
    /// Prefs key-value JSON object
    /// </summary>
    [JsonPropertyName("prefs")]
    public IDictionary<string, string> Preferences { get; set; } = new Dictionary<string, string>();
}
