using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for deleting an identity
/// </summary>
public class DeleteIdentityRequest : BaseRequest<DeleteIdentityRequest, DeleteIdentityRequestValidator>
{
    /// <summary>
    /// Identity ID
    /// </summary>
    [JsonPropertyName("identityId")]
    public string IdentityId { get; set; } = string.Empty;
}
