using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Client;

/// <summary>
/// <para>The Account service allows you to authenticate and manage a user account. You can use the account service to update user information, retrieve the user sessions across different devices, and fetch the user security logs with his or her recent activity.</para>
/// <para>Register new user accounts with the Create Account, Create Magic URL session, or Create Phone session endpoint.You can authenticate the user account by using multiple sign-in methods available.Once the user is authenticated, a new session object will be created to allow the user to access his or her private data and settings.</para>
/// <para>This service also exposes an endpoint to save and read the user preferences as a key-value object. This feature is handy if you want to allow extra customization in your app.Common usage for this feature may include saving the user's preferred locale, timezone, or custom app theme.</para>
/// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account">Appwrite Docs</see></para>
/// </summary>
public interface IAccountClient
{
    /// <summary>
    /// Use this endpoint to allow a new user to register a new account in your project. After the user registration completes successfully, you can use the /account/verfication route to start verifying the user email address. To allow the new user to login to their new account, you need to create a new account session.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#create">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The created user</returns>
    Task<AppwriteResult<User>> Create(CreateAccountRequest request);

    /// <summary>
    /// Get the currently logged in user.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#get">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> Get();

    /// <summary>
    /// Update currently logged in user account email address. After changing user address, the user confirmation status will get reset. A new confirmation email is not sent automatically however you can use the send confirmation email endpoint again to send the confirmation email. For security measures, user password is required to complete this request. This endpoint can also be used to convert an anonymous account to a normal one, by passing an email address and a new password.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account#updateEmail">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdateEmail(UpdateEmailRequest request);

    /// <summary>
    /// Update currently logged in user account name
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account#updateName">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdateName(UpdateNameRequest request);

    /// <summary>
    /// Update currently logged in user password. For validation, user is required to pass in the new password, and the old password. For users created with OAuth, Team Invites and Magic URL, oldPassword is optional
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account#updatePassword">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdatePassword(UpdatePasswordRequest request);

    /// <summary>
    /// Update the currently logged in user's phone number. After updating the phone number, the phone verification status will be reset. A confirmation SMS is not sent automatically, however you can use the POST /account/verification/phone endpoint to send a confirmation SMS
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#updatePhone">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdatePhone(UpdatePhoneRequest request);

    /// <summary>
    /// Get the preferences as a dictionary for the currently logged in user
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#getPrefs">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>A dictionary of the user preferences</returns>
    Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetAccountPreferences();

    /// <summary>
    /// Update currently logged in user account preferences. The object you pass is stored as is, and replaces any previous value. The maximum allowed prefs size is 64kB and throws error if exceeded
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#updatePrefs">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="preferences">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdatePreferences(UpdatePreferencesRequest request);

    /// <summary>
    /// <para>Sends the user an email with a secret key for creating a session. If the provided user ID has not be registered, a new user will be created. Use the returned user ID and secret and submit a request to the Create Session endpoint to complete the login process. The secret sent to the user's email is valid for 15 minutes.</para>
    /// <para>A user is limited to 10 active sessions at a time by default. <see href="https://appwrite.io/docs/products/auth/security#limits">Learn more about session limits.</see></para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createEmailToken">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The token</returns>
    Task<AppwriteResult<Token>> CreateEmailToken(CreateEmailTokenRequest request);

    /// <summary>
    /// Use this endpoint to create a session from token. Provide the userId and secret parameters from the successful response of authentication flows initiated by token creation. For example, magic URL and phone login.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The session</returns>
    Task<AppwriteResult<Session>> CreateSession(CreateSessionRequest request);

    /// <summary>
    /// Use this endpoint to get a logged in user's session using a Session ID. Inputting 'current' will return the current session being used
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#getSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="sessionId">Session ID. Use the string 'current' to get the current device session</param>
    /// <returns>The session</returns>
    Task<AppwriteResult<Session>> GetSession(string sessionId = "current");

    /// <summary>
    /// Use this endpoint to extend a session's length. Extending a session is useful when session expiry is short. If the session was created using an OAuth provider, this endpoint refreshes the access token from the provider.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#updateSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="sessionId">Session ID. Use the string 'current' to update the current device session.</param>
    /// <returns>The session</returns>
    Task<AppwriteResult<Session>> UpdateSession(string sessionId = "current");

    /// <summary>
    /// <para>Use this endpoint to send a verification message to your user email address to confirm they are the valid owners of that address. Both the userId and secret arguments will be passed as query parameters to the URL you have provided to be attached to the verification email. The provided URL should redirect the user back to your app and allow you to complete the verification process by verifying both the userId and secret parameters. Learn more about how to <see href="https://appwrite.io/docs/references/cloud/client-web/account#updateVerification">complete the verification process</see>. The verification link sent to the user's email address is valid for 7 days.</para>
    /// <para>Please note that in order to avoid a <see href="https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.md">Redirect Attack</see>, the only valid redirect URLs are the ones from domains you have set when adding your platforms in the console interface.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createVerification">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The token</returns>
    Task<AppwriteResult<Token>> CreateEmailVerification(CreateEmailVerificationRequest request);

    /// <summary>
    /// Use this endpoint to complete the user email verification process. Use both the userId and secret parameters that were attached to your app URL to verify the user email ownership. If confirmed this route will return a 200 status code.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#updateVerification">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The token</returns>
    Task<AppwriteResult<Token>> CreateEmailVerificationConfirmation(CreateEmailVerificationConfirmationRequest request);

    /// <summary>
    /// Use this endpoint to create a JSON Web Token. You can use the resulting JWT to authenticate on behalf of the current user when working with the Appwrite server-side API and SDKs. The JWT secret is valid for 15 minutes from its creation and will be invalid if the user will logout in that time frame.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createJWT">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The JWT</returns>
    Task<AppwriteResult<Jwt>> CreateJwt();

    /// <summary>
    /// Get the list of latest security activity logs for the currently logged in user. Each log returns user IP address, location and date and time of log.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#listLogs">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="queries">Array of query strings generated using the Query class provided by the SDK. <see href="https://appwrite.io/docs/queries">Learn more about queries</see>. Only supported methods are limit and offset</param>
    /// <returns>The Logs List</returns>
    Task<AppwriteResult<LogsList>> ListLogs(List<Query>? queries = null);

    /// <summary>
    /// Add an authenticator app to be used as an MFA factor. Verify the authenticator using <see cref="VerifyAuthenticator"/>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createMfaAuthenticator">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="type">Type of authenticator. Must be `totp`</param>
    /// <returns>The MfaType</returns>
    Task<AppwriteResult<MfaType>> AddAuthenticator(AddAuthenticatorRequest request);

    /// <summary>
    /// Verify an authenticator app after adding it using <see cref="AddAuthenticator"/>.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#updateMfaAuthenticator">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <param name="type">Type of authenticator</param>
    /// <returns>The User</returns>
    Task<AppwriteResult<User>> VerifyAuthenticator(VerifyAuthenticatorRequest request);

    /// <summary>
    /// Enable or disable MFA on an account
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#updateMFA">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The user</returns>
    Task<AppwriteResult<User>> UpdateMfa(UpdateMfaRequest request);

    /// <summary>
    /// Delete an authenticator for a user by ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#deleteMfaAuthenticator">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The result</returns>
    Task<AppwriteResult> DeleteAuthenticator(DeleteAuthenticatorRequest request);

    /// <summary>
    /// Begin the process of MFA verification after sign-in. Finish the flow with <see cref="Create2faChallengeConfirmation(Create2faChallengeConfirmationRequest)"/>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createMfaChallenge">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The Mfa Challenge</returns>
    Task<AppwriteResult<MfaChallenge>> Create2faChallenge(Create2faChallengeRequest request);

    /// <summary>
    /// Complete the MFA challenge by providing the one-time password. Finish the process of MFA verification by providing the one-time password. To begin the flow, use <see cref="Create2faChallenge(Create2faChallengeRequest)"/>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#updateMfaChallenge">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The result</returns>
    Task<AppwriteResult> Create2faChallengeConfirmation(Create2faChallengeConfirmationRequest request);

    /// <summary>
    /// List the factors available on the account to be used as a MFA challange
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#listMfaFactors">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The Mfa Factors</returns>
    Task<AppwriteResult<MfaFactors>> ListFactors();

    /// <summary>
    /// Generate recovery codes as backup for MFA flow. It's recommended to generate and show then immediately after user successfully adds their authenticator. Recovery codes can be used as a MFA verification type in <see cref="Create2faChallenge(Create2faChallengeRequest)"/>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createMfaRecoveryCodes">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The Mfa Recovery Codes</returns>
    Task<AppwriteResult<MfaRecoveryCodes>> CreateMfaRecoveryCodes();

    /// <summary>
    /// Get recovery codes that can be used as backup for MFA flow. Before getting codes, they must be generated using <see cref="CreateMfaRecoveryCodes"/> method. An OTP challenge is required to read recovery codes
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#getMfaRecoveryCodes">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The Mfa Recovery Codes</returns>
    Task<AppwriteResult<MfaRecoveryCodes>> GetMfaRecoveryCodes();

    /// <summary>
    /// Regenerate recovery codes that can be used as backup for MFA flow. Before regenerating codes, they must be first generated using <see cref="CreateMfaRecoveryCodes"/> method. An OTP challenge is required to regenreate recovery codes
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#updateMfaRecoveryCodes">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The Mfa Recovery Codes</returns>
    Task<AppwriteResult<MfaRecoveryCodes>> RegenerateMfaRecoveryCodes();

    /// <summary>
    /// Sends the user an email with a temporary secret key for password reset. When the user clicks the confirmation link he is redirected back to your app password reset URL with the secret key and email address values attached to the URL query string. Use the query string params to submit a request to <see cref="CreatePasswordRecoveryConfirmation(CreatePasswordRecoveryConfirmationRequest)"/> to complete the process. The verification link sent to the user's email address is valid for 1 hour
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createRecovery">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The Token</returns>
    Task<AppwriteResult<Token>> CreatePasswordRecovery(CreatePasswordRecoveryRequest request);

    /// <summary>
    /// <para>Use this endpoint to complete the user account password reset. Both the userId and secret arguments will be passed as query parameters to the redirect URL you have provided when sending your request to <see cref="CreatePasswordRecovery(CreatePasswordRecoveryRequest)"/></para>
    /// <para>Please note that in order to avoid a <see href="https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.md">Redirect Attack</see> the only valid redirect URLs are the ones from domains you have set when adding your platforms in the console interface</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#updateRecovery">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The Token</returns>
    Task<AppwriteResult<Token>> CreatePasswordRecoveryConfirmation(CreatePasswordRecoveryConfirmationRequest request);

    /// <summary>
    /// Get the list of active sessions across different devices for the currently logged in user
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#listSessions">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The Sessions List</returns>
    Task<AppwriteResult<SessionsList>> ListSessions();

    /// <summary>
    /// Delete all sessions from the user account and remove any sessions cookies from the end client
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#deleteSessions">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The result</returns>
    Task<AppwriteResult> DeleteSessions();

    /// <summary>
    /// Use this endpoint to allow a new user to register an anonymous account in your project. This route will also create a new session for the user. To allow the new user to convert an anonymous account to a normal account, you need to call <see cref="UpdateEmail(UpdateEmailRequest)"/> or create an OAuth2 session
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createAnonymousSession">Appwrite Docs</see></para>
    /// </summary>
    /// <returns>The Session</returns>
    Task<AppwriteResult<Session>> CreateAnonymousSession();

    /// <summary>
    /// <para>Allow the user to login into their account by providing a valid email and password combination. This route will create a new session for the user.</para>
    /// <para>A user is limited to 10 active sessions at a time by default. <see href="https://appwrite.io/docs/authentication-security#limits">Learn more about session limits</see>.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createEmailPasswordSession">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The Session</returns>
    Task<AppwriteResult<Session>> CreateEmailPasswordSession(CreateEmailPasswordSessionRequest request);

    /// <summary>
    /// <para>Allow the user to login to their account using the OAuth2 provider of their choice. Each OAuth2 provider should be enabled from the Appwrite console first. Use the success and failure arguments to provide a redirect URL's back to your app when login is completed.</para>
    /// <para>If there is already an active session, the new session will be attached to the logged-in account. If there are no active sessions, the server will attempt to look for a user with the same email address as the email received from the OAuth2 provider and attach the new session to the existing user. If no matching user is found - the server will create a new user.</para>
    /// <para>A user is limited to 10 active sessions at a time by default. <see href="https://appwrite.io/docs/authentication-security#limits">Learn more about session limits</see></para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/account#createOAuth2Session">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The CreateOauth2Session object</returns>
    AppwriteResult<CreateOauth2Session> CreateOauth2Session(CreateOauth2SessionRequest request);
}
