using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Servers;

/// <summary>
/// <para>The Account service allows you to authenticate and manage a user account. You can use the account service to update user information, retrieve the user sessions across different devices, and fetch the user security logs with his or her recent activity.</para>
/// <para>Register new user accounts with the Create Account, Create Magic URL session, or Create Phone session endpoint.You can authenticate the user account by using multiple sign-in methods available.Once the user is authenticated, a new session object will be created to allow the user to access his or her private data and settings.</para>
/// <para>This service also exposes an endpoint to save and read the user preferences as a key-value object. This feature is handy if you want to allow extra customization in your app.Common usage for this feature may include saving the user's preferred locale, timezone, or custom app theme.</para>
/// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account">Appwrite Docs</see></para>
/// </summary>
public interface IAccountServer
{
    /// <summary>
    /// Use this endpoint to allow a new user to register a new account in your project. After the user registration completes successfully, you can use the /account/verfication route to start verifying the user email address. To allow the new user to login to their new account, you need to create a new account session.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account#create">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The created user</returns>
    Task<AppwriteResult<User>> Create(CreateAccountRequest request);

    /// <summary>
    /// <para>Sends the user an email with a secret key for creating a session. If the provided user ID has not be registered, a new user will be created. Use the returned user ID and secret and submit a request to the Create Session endpoint to complete the login process. The secret sent to the user's email is valid for 15 minutes.</para>
    /// <para>A user is limited to 10 active sessions at a time by default. <see href="https://appwrite.io/docs/products/auth/security#limits">Learn more about session limits.</see></para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account#createEmailToken">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The token</returns>
    Task<AppwriteResult<Token>> CreateEmailToken(CreateEmailTokenRequest request);

    /// <summary>
    /// Use this endpoint to allow a new user to register an anonymous account in your project. This route will also create a new session for the user. To allow the new user to convert an anonymous account to a normal account, you need to call <see cref="UpdateEmail(UpdateEmailRequest)"/> or create an OAuth2 session
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account#createAnonymousSession">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The Session</returns>
    Task<AppwriteResult<Session>> CreateAnonymousSession();

    /// <summary>
    /// <para>Allow the user to login into their account by providing a valid email and password combination. This route will create a new session for the user.</para>
    /// <para>A user is limited to 10 active sessions at a time by default. <see href="https://appwrite.io/docs/authentication-security#limits">Learn more about session limits</see>.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account#createEmailPasswordSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The Session</returns>
    Task<AppwriteResult<Session>> CreateEmailPasswordSession(CreateEmailPasswordSessionRequest request);

    /// <summary>
    /// Use this endpoint to create a session from token. Provide the userId and secret parameters from the successful response of authentication flows initiated by token creation. For example, magic URL and phone login.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account#createSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The session</returns>
    Task<AppwriteResult<Session>> CreateSession(CreateSessionRequest request);

    /// <summary>
    /// <para>Sends the user an email with a secret key for creating a session. If the provided user ID has not been registered, a new user will be created. When the user clicks the link in the email, the user is redirected back to the URL you provided with the secret key and userId values attached to the URL query string. Use the query string parameters to submit a request to the <see cref="CreateSession(CreateSessionRequest)"/> endpoint to complete the login process. The link sent to the user's email address is valid for 1 hour. If you are on a mobile device you can leave the URL parameter empty, so that the login completion will be handled by your Appwrite instance by default.</para>
    /// <para>A user is limited to 10 active sessions at a time by default. <see href="https://appwrite.io/docs/authentication-security#limits">Learn more about session limits</see>.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account#createMagicURLToken">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The token</returns>
    Task<AppwriteResult<Token>> CreateMagicUrlToken(CreateMagicUrlTokenRequest request);

    /// <summary>
    /// Use this endpoint to create a session from token. Provide the <see cref="UpdateMagicUrlSessionRequest.UserId"/> and <see cref="UpdateMagicUrlSessionRequest.Secret"/> parameters from the successful response of authentication flows initiated by token creation. For example, magic URL and phone login.
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The session</returns>
    Task<AppwriteResult<Session>> UpdateMagicUrlSession(UpdateMagicUrlSessionRequest request);
}
