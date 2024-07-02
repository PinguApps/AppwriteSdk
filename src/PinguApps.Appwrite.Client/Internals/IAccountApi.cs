using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Client.Internals;

public interface IAccountApi : IBaseApi
{
    [Get("/account")]
    Task<IApiResponse<User>> GetAccount([Header("x-appwrite-session")] string? session);
}
