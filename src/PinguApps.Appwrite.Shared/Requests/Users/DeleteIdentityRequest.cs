using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class DeleteIdentityRequest : BaseRequest<DeleteIdentityRequest, DeleteIdentityRequestValidator>
{
    /// <summary>
    /// Identity ID
    /// </summary>
    public string IdentityId { get; set; } = string.Empty;
}
