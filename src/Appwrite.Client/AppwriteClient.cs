namespace Appwrite.Client;
public partial class AppwriteClient
{
    public AccountClient Account { get; }

    public AppwriteClient(AccountClient accountClient)
    {
        Account = accountClient;
    }

    public string? Session { get; private set; }

    public void SetSession(string? session)
    {
        Session = session;
        Account.SetSession(session);
    }
}
