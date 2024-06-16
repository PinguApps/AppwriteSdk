using System.Threading.Tasks;
using PinguApps.Appwrite.Client.Models;

namespace PinguApps.Appwrite.Client;
public interface IAccountClient
{
    Task<AppwriteResult<User>> Get();
}