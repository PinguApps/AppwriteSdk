using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Internals;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Server.Internals;
public interface IAccountApi : IBaseApi, IAccountApiBase
{
    [Post("/account")]
    Task<IApiResponse<User>> CreateAccount(CreateAccountRequest request);
}
