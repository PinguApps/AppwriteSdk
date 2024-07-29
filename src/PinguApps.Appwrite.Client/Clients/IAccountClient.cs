using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Client;

/// <summary>
/// <para>The Account service allows you to authenticate and manage a user account. You can use the account service to update user information, retrieve the user sessions across different devices, and fetch the user security logs with his or her recent activity.</para>
/// <para>Register new user accounts with the Create Account, Create Magic URL session, or Create Phone session endpoint.You can authenticate the user account by using multiple sign-in methods available.Once the user is authenticated, a new session object will be created to allow the user to access his or her private data and settings.</para>
/// <para>This service also exposes an endpoint to save and read the user preferences as a key-value object. This feature is handy if you want to allow extra customization in your app.Common usage for this feature may include saving the user's preferred locale, timezone, or custom app theme.</para>
/// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account">Appwrite Docs</see></para>
/// </summary>
public interface IAccountClient
{
    /// <summary>
    /// Use this endpoint to allow a new user to register a new account in your project. After the user registration completes successfully, you can use the /account/verfication route to start verifying the user email address. To allow the new user to login to their new account, you need to create a new account session.
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account#create">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The created user</returns>
    Task<AppwriteResult<User>> Create(CreateAccountRequest request);

    /// <summary>
    /// Get the currently logged in user.
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account#get">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> Get();

    /// <summary>
    /// Update currently logged in user account email address. After changing user address, the user confirmation status will get reset. A new confirmation email is not sent automatically however you can use the send confirmation email endpoint again to send the confirmation email. For security measures, user password is required to complete this request. This endpoint can also be used to convert an anonymous account to a normal one, by passing an email address and a new password.
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/server-rest/account#updateEmail">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdateEmail(UpdateEmailRequest request);

    /// <summary>
    /// Update currently logged in user account name
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/server-rest/account#updateName">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdateName(UpdateNameRequest request);

    /// <summary>
    /// Update currently logged in user password. For validation, user is required to pass in the new password, and the old password. For users created with OAuth, Team Invites and Magic URL, oldPassword is optional
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/server-rest/account#updatePassword">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdatePassword(UpdatePasswordRequest request);

    /// <summary>
    /// Update the currently logged in user's phone number. After updating the phone number, the phone verification status will be reset. A confirmation SMS is not sent automatically, however you can use the POST /account/verification/phone endpoint to send a confirmation SMS
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account#updatePhone">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdatePhone(UpdatePhoneRequest request);

    /// <summary>
    /// Get the preferences as a dictionary for the currently logged in user
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account#getPrefs">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>A dictionary of the user preferences</returns>
    Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetAccountPreferences();

    /// <summary>
    /// Update currently logged in user account preferences. The object you pass is stored as is, and replaces any previous value. The maximum allowed prefs size is 64kB and throws error if exceeded
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account#updatePrefs">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="preferences">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdatePreferences(UpdatePreferencesRequest request);

    /// <summary>
    /// <para>Sends the user an email with a secret key for creating a session. If the provided user ID has not be registered, a new user will be created. Use the returned user ID and secret and submit a request to the Create Session endpoint to complete the login process. The secret sent to the user's email is valid for 15 minutes.</para>
    /// <para>A user is limited to 10 active sessions at a time by default. <see href="https://appwrite.io/docs/products/auth/security#limits">Learn more about session limits.</see></para>
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account#createEmailToken">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The token</returns>
    Task<AppwriteResult<Token>> CreateEmailToken(CreateEmailTokenRequest request);

    /// <summary>
    /// Use this endpoint to create a session from token. Provide the userId and secret parameters from the successful response of authentication flows initiated by token creation. For example, magic URL and phone login.
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account#createSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The session</returns>
    Task<AppwriteResult<Session>> CreateSession(CreateSessionRequest request);

    /// <summary>
    /// Use this endpoint to get a logged in user's session using a Session ID. Inputting 'current' will return the current session being used
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account#getSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="sessionId">Session ID. Use the string 'current' to get the current device session</param>
    /// <returns>The session</returns>
    Task<AppwriteResult<Session>> GetSession(string sessionId = "current");

    /// <summary>
    /// Use this endpoint to extend a session's length. Extending a session is useful when session expiry is short. If the session was created using an OAuth provider, this endpoint refreshes the access token from the provider.
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account#updateSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="sessionId">Session ID. Use the string 'current' to update the current device session.</param>
    /// <returns>The session</returns>
    Task<AppwriteResult<Session>> UpdateSession(string sessionId = "current");
}
