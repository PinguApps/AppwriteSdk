using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Internals;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Client.Internals;

public interface IAccountApi : IBaseApi, IAccountApiBase
{
    [Get("/account")]
    Task<IApiResponse<User>> GetAccountAsync([Header("X-Appwrite-Session")] string? session);
}
