using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;

/// <summary>
/// The request for updating a user's labels
/// </summary>
public class UpdateUserLabelsRequest : UserIdBaseRequest<UpdateUserLabelsRequest, UpdateUserLabelsRequestValidator>
{
    /// <summary>
    /// Array of user labels. Replaces the previous labels. Maximum of 1000 labels are allowed, each up to 36 alphanumeric characters long.
    /// </summary>
    [JsonPropertyName("labels")]
    public List<string> Labels { get; set; } = [];
}
