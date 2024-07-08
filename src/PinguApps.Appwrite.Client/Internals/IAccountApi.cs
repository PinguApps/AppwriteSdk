using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Client.Internals;

public interface IAccountApi : IBaseApi
{
    [Get("/account")]
    Task<IApiResponse<User>> GetAccount([Header("x-appwrite-session")] string? session);

    [Post("/account")]
    Task<IApiResponse<User>> CreateAccount(CreateAccountRequest request);

    [Patch("/account/email")]
    Task<IApiResponse<User>> UpdateEmail([Header("x-appwrite-session")] string? session, UpdateEmailRequest request);

    [Patch("/account/name")]
    Task<IApiResponse<User>> UpdateName([Header("x-appwrite-session")] string? session, UpdateNameRequest name);

    [Patch("/account/password")]
    Task<IApiResponse<User>> UpdatePassword([Header("x-appwrite-session")] string? session, UpdatePasswordRequest name);
}
