using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Clients;

/// <summary>
/// The Users service allows you to manage your project users. Use this service to search, block, and view your users' info, current sessions, and latest activity logs. You can also use the Users service to edit your users' preferences and personal info.
/// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users">Appwrite Docs</see></para>
/// </summary>
public interface IUsersClient
{
    /// <summary>
    /// Get a list of all the project's users. You can use the query params to filter your results.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#list">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The Users List</returns>
    Task<AppwriteResult<UsersList>> ListUsers(ListUsersRequest request);

    /// <summary>
    /// Create a new User
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#create">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> CreateUser(CreateUserRequest request);

    /// <summary>
    /// Create a new user. Password provided must be hashed with the <see href="https://en.wikipedia.org/wiki/Argon2">Argon2</see> algorithm. Use <see cref="CreateUser(CreateUserRequest)"/> to create users with a plain text password.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createArgon2User">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> CreateUserWithArgon2Password(CreateUserWithArgon2PasswordRequest request);

    /// <summary>
    /// Create a new user. Password provided must be hashed with the <see href="https://en.wikipedia.org/wiki/Bcrypt">Bcrypt</see> algorithm. Use <see cref="CreateUser(CreateUserRequest)"/> to create users with a plain text password.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createBcryptUser">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> CreateUserWithBcryptPassword(CreateUserWithBcryptPasswordRequest request);

    /// <summary>
    /// Get identities for all users
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#listIdentities">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The identities list</returns>
    Task<AppwriteResult<IdentitiesList>> ListIdentities(ListIdentitiesRequest request);

    /// <summary>
    /// Delete an identity by its unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#deleteIdentity">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 success code</returns>
    Task<AppwriteResult> DeleteIdentity(DeleteIdentityRequest request);

    /// <summary>
    /// Create a new user. Password provided must be hashed with the <see href="https://en.wikipedia.org/wiki/MD5">MD5</see> algorithm. Use <see cref="CreateUser(CreateUserRequest)"/> to create users with a plain text password.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createMD5User">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> CreateUserWithMd5Password(CreateUserWithMd5PasswordRequest request);

    /// <summary>
    /// Create a new user. Password provided must be hashed with the <see href="https://www.openwall.com/phpass/">PHPass</see> algorithm. Use <see cref="CreateUser(CreateUserRequest)"/> to create users with a plain text password.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createMD5User">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> CreateUserWithPhpassPassword(CreateUserWithPhpassPasswordRequest request);

    /// <summary>
    /// Create a new user. Password provided must be hashed with the <see href="https://github.com/Tarsnap/scrypt">Scrypt</see> algorithm. Use <see cref="CreateUser(CreateUserRequest)"/> to create users with a plain text password.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createScryptUser">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> CreateUserWithScryptPassword(CreateUserWithScryptPasswordRequest request);

    /// <summary>
    /// Create a new user. Password provided must be hashed with the <see href="https://gist.github.com/Meldiron/eecf84a0225eccb5a378d45bb27462cc">Scrypt Modified</see> algorithm. Use <see cref="CreateUser(CreateUserRequest)"/> to create users with a plain text password.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createScryptUser">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> CreateUserWithScryptModifiedPassword(CreateUserWithScryptModifiedPasswordRequest request);

    /// <summary>
    /// Create a new user. Password provided must be hashed with the <see href="https://en.wikipedia.org/wiki/Secure_Hash_Algorithm">SHA</see> algorithm. Use <see cref="CreateUser(CreateUserRequest)"/> to create users with a plain text password.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createScryptUser">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> CreateUserWithShaPassword(CreateUserWithShaPasswordRequest request);

    /// <summary>
    /// Delete a user by its unique ID, thereby releasing it's ID. Since ID is released and can be reused, all user-related resources like documents or storage files should be deleted before user deletion. If you want to keep ID reserved, use <see cref="UpdateUserStatus(UpdateUserStatusRequest)"/> instead.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#delete">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 success code</returns>
    Task<AppwriteResult> DeleteUser(DeleteUserRequest request);

    /// <summary>
    /// Get a user by its unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#get">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> GetUser(GetUserRequest request);

    /// <summary>
    /// Update the user email by its unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#updateEmail">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdateEmail(UpdateEmailRequest request);

    /// <summary>
    /// Use this endpoint to create a JSON Web Token for user by its unique ID. You can use the resulting JWT to authenticate on behalf of the user. The JWT secret will become invalid if the session it uses gets deleted.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createJWT">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The jwt</returns>
    Task<AppwriteResult<Jwt>> CreateUserJwt(CreateUserJwtRequest request);

    /// <summary>
    /// <para>Update the user labels by its unique ID.</para>
    /// <para>Labels can be used to grant access to resources. While teams are a way for user's to share access to a resource, labels can be defined by the developer to grant access without an invitation. See the <see href="https://appwrite.io/docs/permissions">Permissions docs</see> for more info</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#updateLabels">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdateUserLabels(UpdateUserLabelsRequest request);

    /// <summary>
    /// Get the user activity logs list by its unique ID.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#listLogs">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The logs list</returns>
    Task<AppwriteResult<LogsList>> ListUserLogs(ListUserLogsRequest request);

    /// <summary>
    /// Get the user membership list by its unique ID.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#listMemberships">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The memberships list</returns>
    Task<AppwriteResult<MembershipsList>> ListUserMemberships(ListUserMembershipsRequest request);

    /// <summary>
    /// Enable or disable MFA on a user account.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#updateMfa">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdateMfa(UpdateMfaRequest request);

    /// <summary>
    /// Delete an authenticator app.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#deleteMfaAuthenticator">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult> DeleteAuthenticator(DeleteAuthenticatorRequest request);

    /// <summary>
    /// List the factors available on the account to be used as a MFA challange.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#listMfaFactors">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The mfa factors</returns>
    Task<AppwriteResult<MfaFactors>> ListFactors(ListFactorsRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<MfaRecoveryCodes>> GetMfaRecoveryCodes(GetMfaRecoveryCodesRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<MfaRecoveryCodes>> CreateMfaRecoveryCodes(CreateMfaRecoveryCodesRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<MfaRecoveryCodes>> RegenerateMfaRecoveryCodes(RegenerateMfaRecoveryCodesRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdateName(UpdateNameRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdatePassword(UpdatePasswordRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdatePhone(UpdatePhoneRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetUserPreferences(GetUserPreferencesRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<IReadOnlyDictionary<string, string>>> UpdateUserPreferences(UpdateUserPreferencesRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteUserSessions(DeleteUserSessionsRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<SessionsList>> ListUserSessions(ListUserSessionsRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<Session>> CreateSession(CreateSessionRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteUserSession(DeleteUserSessionRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdateUserStatus(UpdateUserStatusRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<TargetList>> ListUserTargets(ListUserTargetsRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<Target>> CreateUserTarget(CreateUserTargetRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteUserTarget(DeleteUserTargetRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<Target>> GetUserTarget(GetUserTargetRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<Target>> UpdateUserTarget(UpdateUserTargertRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<Token>> CreateToken(CreateTokenRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdateEmailVerification(UpdateEmailVerificationRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdatePhoneVerification(UpdatePhoneVerificationRequest request);
}
