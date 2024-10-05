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
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<UsersList>> ListUsers(ListUsersRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> CreateUser(CreateUserRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> CreateUserWithArgon2Password(CreateUserWithArgon2PasswordRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> CreateUserWithBcryptPassword(CreateUserWithBcryptPasswordRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<IdentitiesList>> ListIdentities(ListIdentitiesRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteIdentity(DeleteIdentityRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> CreateUserWithMd5Password(CreateUserWithMd5PasswordRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> CreateUserWithPhpassPassword(CreateUserWithPhpassPasswordRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> CreateUserWithScryptPassword(CreateUserWithScryptPasswordRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> CreateUserWithScryptModifiedPassword(CreateUserWithScryptModifiedPasswordRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> CreateUserWithShaPassword(CreateUserWithShaPasswordRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteUser(DeleteUserRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> GetUser(GetUserRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdateEmail(UpdateEmailRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<Jwt>> CreateUserJwt(CreateUserJwtRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdateUserLabels(UpdateUserLabelsRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<LogsList>> ListUserLogs(ListUserLogsRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<MembershipsList>> ListUserMemberships(ListUserMembershipsRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> UpdateMfa(UpdateMfaRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult<User>> DeleteAuthenticator(DeleteAuthenticatorRequest request);
    [Obsolete("This method hasn't yet been implemented.", true)]
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
