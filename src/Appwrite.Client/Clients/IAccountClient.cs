using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Client;
public interface IAccountClient
{
    Task<AppwriteResult<User>> Get();
}
