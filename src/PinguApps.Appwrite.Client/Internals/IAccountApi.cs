using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Client.Internals;

internal interface IAccountApi : IBaseApi
{
    [Get("/account")]
    Task<IApiResponse<User>> GetAccount([Header("x-appwrite-session")] string session);

    [Post("/account")]
    Task<IApiResponse<User>> CreateAccount(CreateAccountRequest request);

    [Patch("/account/email")]
    Task<IApiResponse<User>> UpdateEmail([Header("x-appwrite-session")] string session, UpdateEmailRequest request);

    [Patch("/account/name")]
    Task<IApiResponse<User>> UpdateName([Header("x-appwrite-session")] string session, UpdateNameRequest request);

    [Patch("/account/password")]
    Task<IApiResponse<User>> UpdatePassword([Header("x-appwrite-session")] string session, UpdatePasswordRequest request);

    [Patch("/account/phone")]
    Task<IApiResponse<User>> UpdatePhone([Header("x-appwrite-session")] string session, UpdatePhoneRequest request);

    [Get("/account/prefs")]
    Task<IApiResponse<IReadOnlyDictionary<string, string>>> GetAccountPreferences([Header("x-appwrite-session")] string session);

    [Patch("/account/prefs")]
    Task<IApiResponse<User>> UpdatePreferences([Header("x-appwrite-session")] string session, UpdatePreferencesRequest request);

    [Post("/account/tokens/email")]
    Task<IApiResponse<Token>> CreateEmailToken(CreateEmailTokenRequest request);

    [Post("/account/sessions/token")]
    Task<IApiResponse<Session>> CreateSession(CreateSessionRequest request);

    [Get("/account/sessions/{sessionId}")]
    Task<IApiResponse<Session>> GetSession([Header("x-appwrite-session")] string session, string sessionId);

    [Patch("/account/sessions/{sessionId}")]
    Task<IApiResponse<Session>> UpdateSession([Header("x-appwrite-session")] string session, string sessionId);

    [Post("/account/verification")]
    Task<IApiResponse<Token>> CreateEmailVerification([Header("x-appwrite-session")] string session, CreateEmailVerificationRequest request);

    [Put("/account/verification")]
    Task<IApiResponse<Token>> CreateEmailVerificationConfirmation(CreateEmailVerificationConfirmationRequest request);

    [Post("/account/jwt")]
    Task<IApiResponse<Jwt>> CreateJwt([Header("x-appwrite-session")] string session);

    [Get("/account/logs")]
    [QueryUriFormat(System.UriFormat.Unescaped)]
    Task<IApiResponse<LogsList>> ListLogs([Header("x-appwrite-session")] string session, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries);

    [Post("/account/mfa/authenticators/{type}")]
    Task<IApiResponse<MfaType>> AddAuthenticator([Header("x-appwrite-session")] string session, string type);

    [Put("/account/mfa/authenticators/{type}")]
    Task<IApiResponse<User>> VerifyAuthenticator([Header("x-appwrite-session")] string session, string type, VerifyAuthenticatorRequest request);

    [Patch("/account/mfa")]
    Task<IApiResponse<User>> UpdateMfa([Header("x-appwrite-session")] string session, UpdateMfaRequest request);

    [Delete("/account/mfa/authenticators/{type}")]
    Task<IApiResponse> DeleteAuthenticator([Header("x-appwrite-session")] string session, string type, [Body] DeleteAuthenticatorRequest request);

    [Post("/account/mfa/challenge")]
    Task<IApiResponse<MfaChallenge>> Create2faChallenge([Header("x-appwrite-session")] string session, Create2faChallengeRequest request);

    [Put("/account/mfa/challenge")]
    Task<IApiResponse> Create2faChallengeConfirmation([Header("x-appwrite-session")] string session, Create2faChallengeConfirmationRequest request);

    [Get("/account/mfa/factors")]
    Task<IApiResponse<MfaFactors>> ListFactors([Header("x-appwrite-session")] string session);

    [Post("/account/mfa/recovery-codes")]
    Task<IApiResponse<MfaRecoveryCodes>> CreateMfaRecoveryCodes([Header("x-appwrite-session")] string session);

    [Get("/account/mfa/recovery-codes")]
    Task<IApiResponse<MfaRecoveryCodes>> GetMfaRecoveryCodes([Header("x-appwrite-session")] string session);

    [Patch("/account/mfa/recovery-codes")]
    Task<IApiResponse<MfaRecoveryCodes>> RegenerateMfaRecoveryCodes([Header("x-appwrite-session")] string session);

    [Post("/account/recovery")]
    Task<IApiResponse<Token>> CreatePasswordRecovery(CreatePasswordRecoveryRequest request);

    [Put("/account/recovery")]
    Task<IApiResponse<Token>> CreatePasswordRecoveryConfirmation(CreatePasswordRecoveryConfirmationRequest request);

    [Get("/account/sessions")]
    Task<IApiResponse<SessionsList>> ListSessions([Header("x-appwrite-session")] string session);

    [Delete("/account/sessions")]
    Task<IApiResponse> DeleteSessions([Header("x-appwrite-session")] string session);

    [Post("/account/sessions/anonymous")]
    Task<IApiResponse<Session>> CreateAnonymousSession();

    [Post("/account/sessions/email")]
    Task<IApiResponse<Session>> CreateEmailPasswordSession(CreateEmailPasswordSessionRequest request);

    [Delete("/account/sessions/{sessionId}")]
    Task<IApiResponse> DeleteSession([Header("x-appwrite-session")] string session, string sessionId);

    [Patch("/account/status")]
    Task<IApiResponse<User>> UpdateStatus([Header("x-appwrite-session")] string session);

    [Post("/account/tokens/magic-url")]
    Task<IApiResponse<Token>> CreateMagicUrlToken(CreateMagicUrlTokenRequest request);

    [Put("/account/sessions/magic-url")]
    Task<IApiResponse<Session>> UpdateMagicUrlSession(UpdateMagicUrlSessionRequest request);

    [Get("/account/identities")]
    [QueryUriFormat(System.UriFormat.Unescaped)]
    Task<IApiResponse<IdentitiesList>> ListIdentities([Header("x-appwrite-session")] string session, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries);

    [Delete("/account/identities/{identityId}")]
    Task<IApiResponse> DeleteIdentity([Header("x-appwrite-session")] string session, string identityId);
}
