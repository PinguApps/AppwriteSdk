namespace PinguApps.Appwrite.Server.Clients;

/// <summary>
/// The root of the Client SDK. Access all API sections from here
/// </summary>
public interface IAppwriteClient
{
    /// <summary>
    /// <para>The Account service allows you to authenticate and manage a user account. You can use the account service to update user information, retrieve the user sessions across different devices, and fetch the user security logs with his or her recent activity.</para>
    /// <para>Register new user accounts with the Create Account, Create Magic URL session, or Create Phone session endpoint.You can authenticate the user account by using multiple sign-in methods available.Once the user is authenticated, a new session object will be created to allow the user to access his or her private data and settings.</para>
    /// <para>This service also exposes an endpoint to save and read the user preferences as a key-value object. This feature is handy if you want to allow extra customization in your app.Common usage for this feature may include saving the user's preferred locale, timezone, or custom app theme.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account">Appwrite Docs</see></para>
    /// </summary>
    IAccountClient Account { get; }

    /// <summary>
    /// The Users service allows you to manage your project users. Use this service to search, block, and view your users' info, current sessions, and latest activity logs. You can also use the Users service to edit your users' preferences and personal info.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users">Appwrite Docs</see></para>
    /// </summary>
    IUsersClient Users { get; }
    ITeamsClient Teams { get; }
}
