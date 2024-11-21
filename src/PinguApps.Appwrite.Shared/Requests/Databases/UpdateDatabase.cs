using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to update a database
/// </summary>
public class UpdateDatabase : DatabaseIdBaseRequest<UpdateDatabase, UpdateDatabaseValidator>
{
    /// <summary>
    /// Database name. Max length: 128 chars
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Is database enabled? When set to 'disabled', users cannot access the database but Server SDKs with an API key can still read and write to the database. No data is lost when this is toggled
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; }
}
