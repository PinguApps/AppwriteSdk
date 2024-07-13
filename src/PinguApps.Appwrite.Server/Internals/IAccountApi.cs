using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Server.Internals;
internal interface IAccountApi : IBaseApi
{
    [Post("/account")]
    Task<IApiResponse<User>> CreateAccount(CreateAccountRequest request);
}
