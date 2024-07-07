namespace PinguApps.Appwrite.Client;

/// <summary>
/// The root of the Client SDK. Access all API sections from here
/// </summary>
public interface IAppwriteClient
{
    /// <summary>
    /// The Account API.
    /// <para><see href="https://appwrite.io/docs/references/1.5.x/client-rest/account">Appwrite Docs</see></para>
    /// </summary>
    IAccountClient Account { get; }

    /// <summary>
    /// Set the session of your logged in user
    /// </summary>
    /// <param name="session">The session token</param>
    void SetSession(string? session);
}
