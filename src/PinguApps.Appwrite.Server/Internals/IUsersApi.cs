using System.Threading.Tasks;
using Refit;

namespace PinguApps.Appwrite.Server.Internals;
internal interface IUsersApi : IBaseApi
{
    [Get("/users")]
    Task<IApiResponse> ListUsers();

    [Post("/users")]
    Task<IApiResponse> CreateUser();

    [Post("/users/argon2")]
    Task<IApiResponse> CreateUserWithArgon2Password();

    [Post("/users/bcrypt")]
    Task<IApiResponse> CreateUserWithBcryptPassword();

    [Get("/users/identities")]
    Task<IApiResponse> ListIdentities();

    [Delete("/users/identities/{identityId}")]
    Task<IApiResponse> DeleteIdentity();

    [Post("/users/md5")]
    Task<IApiResponse> CreateUserWithMd5Password();

    [Post("/users/phpass")]
    Task<IApiResponse> CreateUserWithPhpassPassword();

    [Post("/users/scrypt")]
    Task<IApiResponse> CreateUserWithScryptPassword();

    [Post("/users/scrypt-modified")]
    Task<IApiResponse> CreateUserWithScryptModifiedPassword();

    [Post("/users/sha")]
    Task<IApiResponse> CreateUserWithShaPassword();

    [Delete("/users/{userId}")]
    Task<IApiResponse> DeleteUser();

    [Get("/users/{userId}")]
    Task<IApiResponse> GetUser();

    [Patch("/users/{userId}/email")]
    Task<IApiResponse> UpdateEmail();

    [Post("/users/{userId}/jwts")]
    Task<IApiResponse> CreateUserJwt();

    [Put("/users/{userId}/labels")]
    Task<IApiResponse> UpdateUserLabels();

    [Get("/users/{userId}/logs")]
    Task<IApiResponse> ListUserLogs();

    [Get("/users/{userId}/memberships")]
    Task<IApiResponse> ListUserMemberships();

    [Patch("/users/{userId}/mfa")]
    Task<IApiResponse> UpdateMfa();

    [Delete("/users/{userId}/mfa/authenticators/{type}")]
    Task<IApiResponse> DeleteAuthenticator();

    [Get("/users/{userId}/mfa/factors")]
    Task<IApiResponse> ListFactors();

    [Get("/users/{userId}/mfa/recovery-codes")]
    Task<IApiResponse> GetMfaRecoveryCodes();

    [Patch("/users{userId}/mfa/recovery-codes")]
    Task<IApiResponse> CreateMfaRecoveryCodes();

    [Put("/users/{userId}/mfa/recovery-codes")]
    Task<IApiResponse> RegenerateMfaRecoveryCodes();

    [Patch("/users/{userId}/mame")]
    Task<IApiResponse> UpdateName();

    [Patch("/users/{userId}/password")]
    Task<IApiResponse> UpdatePassword();

    [Patch("/users/{userId}/phone")]
    Task<IApiResponse> UpdatePhone();

    [Get("/users/{userId}/prefs")]
    Task<IApiResponse> GetUserPreferences();

    [Patch("/users/{userId}/prefs")]
    Task<IApiResponse> UpdateUserPreferences();

    [Delete("/users/{userId}/sessions")]
    Task<IApiResponse> DeleteUserSessions();

    [Get("/users/{userId}/sessions")]
    Task<IApiResponse> ListUserSessions();

    [Post("/users/{userId}/sessions")]
    Task<IApiResponse> CreateSession();

    [Delete("/users/{userId}/sessions/{sessionId}")]
    Task<IApiResponse> DeleteUserSession();

    [Patch("/users/{userId}/status")]
    Task<IApiResponse> UpdateUserStatus();

    [Get("/users/{userId}/targets")]
    Task<IApiResponse> ListUserTargets();

    [Post("/users/{userId}/targets")]
    Task<IApiResponse> CreateUserTarget();

    [Delete("/users/{userId}/targets/{targetId}")]
    Task<IApiResponse> DeleteUserTarget();

    [Get("/users/{userId}/targets/{targetId}")]
    Task<IApiResponse> GetUserTarget();

    [Patch("/users/{userId}/targets/{targetId}")]
    Task<IApiResponse> UpdateUserTarget();

    [Post("/users/{userId}/tokens")]
    Task<IApiResponse> CreateToken();

    [Patch("/users/{userId}/verification")]
    Task<IApiResponse> UpdateEmailVerification();

    [Patch("/users/{userId}/verification/phone")]
    Task<IApiResponse> UpdatePhoneVerification();
}
