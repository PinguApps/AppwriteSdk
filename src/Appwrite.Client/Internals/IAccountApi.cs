using System.Threading.Tasks;
using Refit;

namespace Appwrite.Client.Internals;

[Headers("X-Appwrite-Response-Format: 1.5.0")]
public interface IAccountApi
{
    [Get("/account")]
    Task<IApiResponse<string>> GetAccountAsync([Header("X-Appwrite-JWT")] string? session);
}
