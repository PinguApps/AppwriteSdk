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
    /// <returns>204 success code</returns>
    Task<AppwriteResult> DeleteAuthenticator(DeleteAuthenticatorRequest request);

    /// <summary>
    /// List the factors available on the account to be used as a MFA challange.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#listMfaFactors">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The mfa factors</returns>
    Task<AppwriteResult<MfaFactors>> ListFactors(ListFactorsRequest request);

    /// <summary>
    /// Get recovery codes that can be used as backup for MFA flow by User ID. Before getting codes, they must be generated using <see cref="CreateMfaRecoveryCodes(CreateMfaRecoveryCodesRequest)"/>.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#getMfaRecoveryCodes">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The mfa recovery codes</returns>
    Task<AppwriteResult<MfaRecoveryCodes>> GetMfaRecoveryCodes(GetMfaRecoveryCodesRequest request);

    /// <summary>
    /// Generate recovery codes used as backup for MFA flow for User ID. Recovery codes can be used as a MFA verification type in createMfaChallenge method by client SDK.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createMfaRecoveryCodes">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The mfa recovery codes</returns>
    Task<AppwriteResult<MfaRecoveryCodes>> CreateMfaRecoveryCodes(CreateMfaRecoveryCodesRequest request);

    /// <summary>
    /// Regenerate recovery codes that can be used as backup for MFA flow by User ID. Before regenerating codes, they must be first generated using <see cref="CreateMfaRecoveryCodes(CreateMfaRecoveryCodesRequest)"/>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#updateMfaRecoveryCodes">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The mfa recovery codes</returns>
    Task<AppwriteResult<MfaRecoveryCodes>> RegenerateMfaRecoveryCodes(RegenerateMfaRecoveryCodesRequest request);

    /// <summary>
    /// Update the user name by its unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#updateName">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdateName(UpdateNameRequest request);

    /// <summary>
    /// Update the user password by its unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#updatePassword">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdatePassword(UpdatePasswordRequest request);

    /// <summary>
    /// Update the user phone by its unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#updatePhone">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdatePhone(UpdatePhoneRequest request);

    /// <summary>
    /// Get the user preferences by its unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#getPrefs">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user preferences</returns>
    Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetUserPreferences(GetUserPreferencesRequest request);

    /// <summary>
    /// Update the user preferences by its unique ID. The object you pass is stored as is, and replaces any previous value. The maximum allowed prefs size is 64kB and throws error if exceeded
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#updatePrefs">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user preferences</returns>
    Task<AppwriteResult<IReadOnlyDictionary<string, string>>> UpdateUserPreferences(UpdateUserPreferencesRequest request);

    /// <summary>
    /// Delete all user's sessions by using the user's unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#deleteSessions">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 success code</returns>
    Task<AppwriteResult> DeleteUserSessions(DeleteUserSessionsRequest request);

    /// <summary>
    /// Get the user sessions list by its unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#listSessions">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The sessions list</returns>
    Task<AppwriteResult<SessionsList>> ListUserSessions(ListUserSessionsRequest request);

    /// <summary>
    /// <para>Creates a session for a user. Returns an immediately usable session object.</para>
    /// <para>If you want to generate a token for a custom authentication flow, use <see cref="CreateToken(CreateTokenRequest)"/>.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The session</returns>
    Task<AppwriteResult<Session>> CreateSession(CreateSessionRequest request);

    /// <summary>
    /// Delete a user sessions by its unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#deleteSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 code</returns>
    Task<AppwriteResult> DeleteUserSession(DeleteUserSessionRequest request);

    /// <summary>
    /// Update the user status by its unique ID. Use this endpoint as an alternative to deleting a user if you want to keep user's ID reserved.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#updateStatus">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdateUserStatus(UpdateUserStatusRequest request);

    /// <summary>
    /// List the messaging targets that are associated with a user.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#listTargets">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The target list</returns>
    Task<AppwriteResult<TargetList>> ListUserTargets(ListUserTargetsRequest request);

    /// <summary>
    /// Create a messaging target
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createTarget">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The target</returns>
    Task<AppwriteResult<Target>> CreateUserTarget(CreateUserTargetRequest request);

    /// <summary>
    /// Delete a messaging target
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#deleteTarget">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204</returns>
    Task<AppwriteResult> DeleteUserTarget(DeleteUserTargetRequest request);

    /// <summary>
    /// Get a user's push notification target by ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#getTarget">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The target</returns>
    Task<AppwriteResult<Target>> GetUserTarget(GetUserTargetRequest request);

    /// <summary>
    /// Update a messaging target
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#updateTarget">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The target</returns>
    Task<AppwriteResult<Target>> UpdateUserTarget(UpdateUserTargertRequest request);

    /// <summary>
    /// Returns a token with a secret key for creating a session. Use the user ID and secret and submit a request to the PUT /account/sessions/token endpoint to complete the login process
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users#createToken">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The token</returns>
    Task<AppwriteResult<Token>> CreateToken(CreateTokenRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdateEmailVerification(UpdateEmailVerificationRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdatePhoneVerification(UpdatePhoneVerificationRequest request);
}
