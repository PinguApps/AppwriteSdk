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
    Task<IApiResponse> DeleteIdentity(string identityId);

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
    Task<IApiResponse> DeleteUser(string userId);

    [Get("/users/{userId}")]
    Task<IApiResponse> GetUser(string userId);

    [Patch("/users/{userId}/email")]
    Task<IApiResponse> UpdateEmail(string userId);

    [Post("/users/{userId}/jwts")]
    Task<IApiResponse> CreateUserJwt(string userId);

    [Put("/users/{userId}/labels")]
    Task<IApiResponse> UpdateUserLabels(string userId);

    [Get("/users/{userId}/logs")]
    Task<IApiResponse> ListUserLogs(string userId);

    [Get("/users/{userId}/memberships")]
    Task<IApiResponse> ListUserMemberships(string userId);

    [Patch("/users/{userId}/mfa")]
    Task<IApiResponse> UpdateMfa(string userId);

    [Delete("/users/{userId}/mfa/authenticators/{type}")]
    Task<IApiResponse> DeleteAuthenticator(string userId, string type);

    [Get("/users/{userId}/mfa/factors")]
    Task<IApiResponse> ListFactors(string userId);

    [Get("/users/{userId}/mfa/recovery-codes")]
    Task<IApiResponse> GetMfaRecoveryCodes(string userId);

    [Patch("/users{userId}/mfa/recovery-codes")]
    Task<IApiResponse> CreateMfaRecoveryCodes(string userId);

    [Put("/users/{userId}/mfa/recovery-codes")]
    Task<IApiResponse> RegenerateMfaRecoveryCodes(string userId);

    [Patch("/users/{userId}/mame")]
    Task<IApiResponse> UpdateName(string userId);

    [Patch("/users/{userId}/password")]
    Task<IApiResponse> UpdatePassword(string userId);

    [Patch("/users/{userId}/phone")]
    Task<IApiResponse> UpdatePhone(string userId);

    [Get("/users/{userId}/prefs")]
    Task<IApiResponse> GetUserPreferences(string userId);

    [Patch("/users/{userId}/prefs")]
    Task<IApiResponse> UpdateUserPreferences(string userId);

    [Delete("/users/{userId}/sessions")]
    Task<IApiResponse> DeleteUserSessions(string userId);

    [Get("/users/{userId}/sessions")]
    Task<IApiResponse> ListUserSessions(string userId);

    [Post("/users/{userId}/sessions")]
    Task<IApiResponse> CreateSession(string userId);

    [Delete("/users/{userId}/sessions/{sessionId}")]
    Task<IApiResponse> DeleteUserSession(string userId, string sessionId);

    [Patch("/users/{userId}/status")]
    Task<IApiResponse> UpdateUserStatus(string userId);

    [Get("/users/{userId}/targets")]
    Task<IApiResponse> ListUserTargets(string userId);

    [Post("/users/{userId}/targets")]
    Task<IApiResponse> CreateUserTarget(string userId);

    [Delete("/users/{userId}/targets/{targetId}")]
    Task<IApiResponse> DeleteUserTarget(string userId, string targetId);

    [Get("/users/{userId}/targets/{targetId}")]
    Task<IApiResponse> GetUserTarget(string userId, string targetId);

    [Patch("/users/{userId}/targets/{targetId}")]
    Task<IApiResponse> UpdateUserTarget(string userId, string targetId);

    [Post("/users/{userId}/tokens")]
    Task<IApiResponse> CreateToken(string userId);

    [Patch("/users/{userId}/verification")]
    Task<IApiResponse> UpdateEmailVerification(string userId);

    [Patch("/users/{userId}/verification/phone")]
    Task<IApiResponse> UpdatePhoneVerification(string userId);
}
