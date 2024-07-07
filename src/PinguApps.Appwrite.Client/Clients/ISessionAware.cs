namespace PinguApps.Appwrite.Client.Clients;

internal interface ISessionAware
{
    public string? Session { get; protected set; }

    public void UpdateSession(string? session) => Session = session;
}
