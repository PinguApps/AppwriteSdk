using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to create a database
/// </summary>
public class CreateDatabaseRequest : BaseRequest<CreateDatabaseRequest, CreateDatabaseRequestValidator>
{
    /// <summary>
    /// Unique Id. Choose a custom ID or generate a random ID with ID.unique(). Valid chars are a-z, A-Z, 0-9, period, hyphen, and underscore. Can't start with a special char. Max length is 36 chars
    /// </summary>
    [JsonPropertyName("databaseId")]
    public string DatabaseId { get; set; } = IdUtils.GenerateUniqueId();

    /// <summary>
    /// Database name. Max length: 128 chars
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Is the database enabled? When set to 'disabled', users cannot access the database but Server SDKs with an API key can still read and write to the database. No data is lost when this is toggled
    /// </summary>
    [JsonPropertyName("enabled")]
    public bool Enabled { get; set; } = true;
}
