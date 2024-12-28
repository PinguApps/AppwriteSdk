namespace PinguApps.Appwrite.Server.Clients;

/// <summary>
/// The root of the Client SDK. Access all API sections from here
/// </summary>
public interface IServerAppwriteClient
{
    /// <summary>
    /// <para>The Account service allows you to authenticate and manage a user account. You can use the account service to update user information, retrieve the user sessions across different devices, and fetch the user security logs with his or her recent activity.</para>
    /// <para>Register new user accounts with the Create Account, Create Magic URL session, or Create Phone session endpoint.You can authenticate the user account by using multiple sign-in methods available.Once the user is authenticated, a new session object will be created to allow the user to access his or her private data and settings.</para>
    /// <para>This service also exposes an endpoint to save and read the user preferences as a key-value object. This feature is handy if you want to allow extra customization in your app.Common usage for this feature may include saving the user's preferred locale, timezone, or custom app theme.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/account">Appwrite Docs</see></para>
    /// </summary>
    IServerAccountClient Account { get; }

    /// <summary>
    /// The Users service allows you to manage your project users. Use this service to search, block, and view your users' info, current sessions, and latest activity logs. You can also use the Users service to edit your users' preferences and personal info.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/users">Appwrite Docs</see></para>
    /// </summary>
    IServerUsersClient Users { get; }

    /// <summary>
    /// <para>The Teams service allows you to group users of your project and to enable them to share <see href="https://appwrite.io/docs/advanced/platform/permissions">read and write</see> access to your project resources, such as database documents or storage files.</para>
    /// <para>Each user who creates a team becomes the team owner and can delegate the ownership role by inviting a new team member. Only team owners can invite new users to their team.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams">Appwrite Docs</see></para>
    /// </summary>
    IServerTeamsClient Teams { get; }

    /// <summary>
    /// <para>The Databases service allows you to create structured collections of documents, query and filter lists of documents, and manage an advanced set of read and write access permissions.</para>
    /// <para>All data returned by the Databases service are represented as structured JSON documents.</para>
    /// <para>The Databases service can contain multiple databases, each database can contain multiple collections. A collection is a group of similarly structured documents. The accepted structure of documents is defined by <see href="https://appwrite.io/docs/products/databases/collections#attributes">collection attributes</see>. The collection attributes help you ensure all your user-submitted data is validated and stored according to the collection structure.</para>
    /// <para>Using Appwrite permissions architecture, you can assign read or write access to each collection or document in your project for either a specific user, team, user role, or even grant it with public access (any). You can learn more about <see href="https://appwrite.io/docs/products/databases/permissions">how Appwrite handles permissions and access control</see>.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/databases">Appwrite Docs</see></para>
    /// </summary>
    IServerDatabasesClient Databases { get; }
}
