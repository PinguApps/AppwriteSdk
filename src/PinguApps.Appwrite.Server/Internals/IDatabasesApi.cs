using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Server.Internals;
internal interface IDatabasesApi : IBaseApi
{
    [Get("/databases")]
    Task<IApiResponse<Database>> GetDatabase(GetDatabaseRequest request);
}
