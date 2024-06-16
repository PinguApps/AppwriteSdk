using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Shared.Internals;
public interface IAccountApiBase
{
    [Get("/account")]
    Task<IApiResponse<User>> GetAccountAsync([Header("X-Appwrite-Session")] string? session);
}
