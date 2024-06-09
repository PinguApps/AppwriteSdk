using System.Threading.Tasks;
using Refit;

namespace Appwrite.Client.Internals;

public interface IAccountApi : IBaseApi
{
    [Get("/account")]
    Task<IApiResponse<string>> GetAccountAsync([Header("X-Appwrite-Session")] string? session);
}
