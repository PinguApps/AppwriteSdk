using System;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;

namespace PinguApps.Appwrite.Server.Clients;

/// <summary>
/// The Users service allows you to manage your project users. Use this service to search, block, and view your users' info, current sessions, and latest activity logs. You can also use the Users service to edit your users' preferences and personal info.
/// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users">Appwrite Docs</see></para>
/// </summary>
public interface IUsersClient
{
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> ListUsers();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateUser();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateUserWithArgon2Password();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateUserWithBcryptPassword();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> ListIdentities();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteIdentity();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateUserWithMd5Password();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateUserWithPhpassPassword();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateUserWithScryptPassword();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateUserWithScryptModifiedPassword();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateUserWithShaPassword();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteUser();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> GetUser();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdateEmail();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateUserJwt();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdateUserLabels();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> ListUserLogs();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> ListUserMemberships();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdateMfa();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteAuthenticator();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> ListFactors();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> GetMfaRecoveryCodes();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateMfaRecoveryCodes();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> RegenerateMfaRecoveryCodes();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdateName();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdatePassword();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdatePhone();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> GetUserPreferences();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdateUserPreferences();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteUserSessions();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> ListUserSessions();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateSession();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteUserSession();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdateUserStatus();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> ListUserTargets();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateUserTarget();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> DeleteUserTarget();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> GetUserTarget();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdateUserTarget();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> CreateToken();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdateEmailVerification();
    [Obsolete("This method hasn't yet been implemented.", true)]
    Task<AppwriteResult> UpdatePhoneVerification();
}
