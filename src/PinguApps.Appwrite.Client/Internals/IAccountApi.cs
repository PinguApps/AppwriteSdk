using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Client.Internals;

internal interface IAccountApi : IBaseApi
{
    [Get("/account")]
    Task<IApiResponse<User>> GetAccount([Header("x-appwrite-session")] string? session);

    [Post("/account")]
    Task<IApiResponse<User>> CreateAccount(CreateAccountRequest request);

    [Patch("/account/email")]
    Task<IApiResponse<User>> UpdateEmail([Header("x-appwrite-session")] string? session, UpdateEmailRequest request);

    [Patch("/account/name")]
    Task<IApiResponse<User>> UpdateName([Header("x-appwrite-session")] string? session, UpdateNameRequest request);

    [Patch("/account/password")]
    Task<IApiResponse<User>> UpdatePassword([Header("x-appwrite-session")] string? session, UpdatePasswordRequest request);

    [Patch("/account/phone")]
    Task<IApiResponse<User>> UpdatePhone([Header("x-appwrite-session")] string? session, UpdatePhoneRequest request);

    [Get("/account/prefs")]
    Task<IApiResponse<IReadOnlyDictionary<string, string>>> GetAccountPreferences([Header("x-appwrite-session")] string? session);

    [Patch("/account/prefs")]
    Task<IApiResponse<User>> UpdatePreferences([Header("x-appwrite-session")] string? session, UpdatePreferencesRequest request);

    [Post("/account/tokens/email")]
    Task<IApiResponse<Token>> CreateEmailToken(CreateEmailTokenRequest request);

    [Post("/account/sessions/token")]
    Task<IApiResponse<Session>> CreateSession(CreateSessionRequest request);
}
