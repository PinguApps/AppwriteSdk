using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Server.Internals;
internal interface IUsersApi : IBaseApi
{
    [Get("/users")]
    [QueryUriFormat(System.UriFormat.Unescaped)]
    Task<IApiResponse<UsersList>> ListUsers([Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries, string? search);

    [Post("/users")]
    Task<IApiResponse<User>> CreateUser(CreateUserRequest request);

    [Post("/users/argon2")]
    Task<IApiResponse<User>> CreateUserWithArgon2Password(CreateUserWithArgon2PasswordRequest request);

    [Post("/users/bcrypt")]
    Task<IApiResponse<User>> CreateUserWithBcryptPassword(CreateUserWithBcryptPasswordRequest request);

    [Get("/users/identities")]
    [QueryUriFormat(System.UriFormat.Unescaped)]
    Task<IApiResponse<IdentitiesList>> ListIdentities([Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries, string? search);

    [Delete("/users/identities/{identityId}")]
    Task<IApiResponse> DeleteIdentity(string identityId);

    [Post("/users/md5")]
    Task<IApiResponse<User>> CreateUserWithMd5Password(CreateUserWithMd5PasswordRequest request);

    [Post("/users/phpass")]
    Task<IApiResponse<User>> CreateUserWithPhpassPassword(CreateUserWithPhpassPasswordRequest request);

    [Post("/users/scrypt")]
    Task<IApiResponse<User>> CreateUserWithScryptPassword(CreateUserWithScryptPasswordRequest request);

    [Post("/users/scrypt-modified")]
    Task<IApiResponse<User>> CreateUserWithScryptModifiedPassword(CreateUserWithScryptModifiedPasswordRequest request);

    [Post("/users/sha")]
    Task<IApiResponse<User>> CreateUserWithShaPassword(CreateUserWithShaPasswordRequest request);

    [Delete("/users/{userId}")]
    Task<IApiResponse> DeleteUser(string userId);

    [Get("/users/{userId}")]
    Task<IApiResponse<User>> GetUser(string userId);

    [Patch("/users/{userId}/email")]
    Task<IApiResponse<User>> UpdateEmail(string userId, UpdateEmailRequest request);

    [Post("/users/{userId}/jwts")]
    Task<IApiResponse<Jwt>> CreateUserJwt(string userId, CreateUserJwtRequest request);

    [Put("/users/{userId}/labels")]
    Task<IApiResponse<User>> UpdateUserLabels(string userId, UpdateUserLabelsRequest request);

    [Get("/users/{userId}/logs")]
    [QueryUriFormat(System.UriFormat.Unescaped)]
    Task<IApiResponse<LogsList>> ListUserLogs(string userId, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries);

    [Get("/users/{userId}/memberships")]
    Task<IApiResponse<MembershipsList>> ListUserMemberships(string userId);

    [Patch("/users/{userId}/mfa")]
    Task<IApiResponse<User>> UpdateMfa(string userId, UpdateMfaRequest request);

    [Delete("/users/{userId}/mfa/authenticators/{type}")]
    Task<IApiResponse<User>> DeleteAuthenticator(string userId, string type);

    [Get("/users/{userId}/mfa/factors")]
    Task<IApiResponse<MfaFactors>> ListFactors(string userId);

    [Get("/users/{userId}/mfa/recovery-codes")]
    Task<IApiResponse<MfaRecoveryCodes>> GetMfaRecoveryCodes(string userId);

    [Patch("/users{userId}/mfa/recovery-codes")]
    Task<IApiResponse<MfaRecoveryCodes>> CreateMfaRecoveryCodes(string userId);

    [Put("/users/{userId}/mfa/recovery-codes")]
    Task<IApiResponse<MfaRecoveryCodes>> RegenerateMfaRecoveryCodes(string userId);

    [Patch("/users/{userId}/mame")]
    Task<IApiResponse<User>> UpdateName(string userId, UpdateNameRequest request);

    [Patch("/users/{userId}/password")]
    Task<IApiResponse<User>> UpdatePassword(string userId, UpdatePasswordRequest request);

    [Patch("/users/{userId}/phone")]
    Task<IApiResponse<User>> UpdatePhone(string userId, UpdatePhoneRequest request);

    [Get("/users/{userId}/prefs")]
    Task<IApiResponse<IReadOnlyDictionary<string, string>>> GetUserPreferences(string userId);

    [Patch("/users/{userId}/prefs")]
    Task<IApiResponse<IReadOnlyDictionary<string, string>>> UpdateUserPreferences(string userId, UpdateUserPreferencesRequest request);

    [Delete("/users/{userId}/sessions")]
    Task<IApiResponse> DeleteUserSessions(string userId);

    [Get("/users/{userId}/sessions")]
    Task<IApiResponse<SessionsList>> ListUserSessions(string userId);

    [Post("/users/{userId}/sessions")]
    Task<IApiResponse<Session>> CreateSession(string userId);

    [Delete("/users/{userId}/sessions/{sessionId}")]
    Task<IApiResponse> DeleteUserSession(string userId, string sessionId);

    [Patch("/users/{userId}/status")]
    Task<IApiResponse<User>> UpdateUserStatus(string userId, UpdateUserStatusRequest request);

    [Get("/users/{userId}/targets")]
    [QueryUriFormat(System.UriFormat.Unescaped)]
    Task<IApiResponse<TargetList>> ListUserTargets(string userId, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries);

    [Post("/users/{userId}/targets")]
    Task<IApiResponse<Target>> CreateUserTarget(string userId, CreateUserTargetRequest request);

    [Delete("/users/{userId}/targets/{targetId}")]
    Task<IApiResponse> DeleteUserTarget(string userId, string targetId);

    [Get("/users/{userId}/targets/{targetId}")]
    Task<IApiResponse<Target>> GetUserTarget(string userId, string targetId);

    [Patch("/users/{userId}/targets/{targetId}")]
    Task<IApiResponse<Target>> UpdateUserTarget(string userId, string targetId, UpdateUserTargertRequest request);

    [Post("/users/{userId}/tokens")]
    Task<IApiResponse<Token>> CreateToken(string userId, CreateTokenRequest request);

    [Patch("/users/{userId}/verification")]
    Task<IApiResponse<User>> UpdateEmailVerification(string userId, UpdateEmailVerificationRequest request);

    [Patch("/users/{userId}/verification/phone")]
    Task<IApiResponse<User>> UpdatePhoneVerification(string userId, UpdatePhoneVerificationRequest request);
}
