using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests.Account;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Server.Internals;
internal interface IAccountApi : IBaseApi
{
    [Post("/account")]
    Task<IApiResponse<User>> CreateAccount(CreateAccountRequest request);

    [Post("/account/sessions/anonymous")]
    Task<IApiResponse<Session>> CreateAnonymousSession();

    [Post("/account/sessions/email")]
    Task<IApiResponse<Session>> CreateEmailPasswordSession(CreateEmailPasswordSessionRequest request);

    [Post("/account/sessions/token")]
    Task<IApiResponse<Session>> CreateSession(CreateSessionRequest request);

    [Post("/account/tokens/email")]
    Task<IApiResponse<Token>> CreateEmailToken(CreateEmailTokenRequest request);

    [Post("/account/tokens/magic-url")]
    Task<IApiResponse<Token>> CreateMagicUrlToken(CreateMagicUrlTokenRequest request);

    [Put("/account/sessions/magic-url")]
    Task<IApiResponse<Session>> UpdateMagicUrlSession(UpdateMagicUrlSessionRequest request);

    [Post("/account/tokens/phone")]
    Task<IApiResponse<Token>> CreatePhoneToken(CreatePhoneTokenRequest request);

    [Put("/account/sessions/phone")]
    Task<IApiResponse<Session>> UpdatePhoneSession(UpdatePhoneSessionRequest request);
}
