using PinguApps.Appwrite.Shared.Requests.Users.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Users;
public class DeleteUserSessionRequest : UserIdBaseRequest<DeleteUserSessionRequest, DeleteUserSessionRequestValidator>
{
    public string SessionId { get; set; } = string.Empty;
}
