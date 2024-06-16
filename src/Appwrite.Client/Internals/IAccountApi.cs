using System.Threading.Tasks;
using Appwrite.Client.Models;
using Refit;

namespace Appwrite.Client.Internals;

public interface IAccountApi : IBaseApi
{
    [Get("/account")]
    Task<IApiResponse<User>> GetAccountAsync([Header("X-Appwrite-Session")] string? session);
}
