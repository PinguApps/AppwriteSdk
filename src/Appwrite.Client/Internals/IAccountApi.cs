using System.Threading.Tasks;
using PinguApps.Appwrite.Client.Models;
using Refit;

namespace PinguApps.Appwrite.Client.Internals;

public interface IAccountApi : IBaseApi
{
    [Get("/account")]
    Task<IApiResponse<User>> GetAccountAsync([Header("X-Appwrite-Session")] string? session);
}
