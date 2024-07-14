using System;
using PinguApps.Appwrite.Client.Clients;

namespace PinguApps.Appwrite.Client;
public class AppwriteClient : IAppwriteClient, ISessionAware
{
    /// <inheritdoc/>
    public IAccountClient Account { get; }

    public AppwriteClient(IAccountClient accountClient)
    {
        Account = accountClient;
        if (Account is ISessionAware sessionAwareAccount)
        {
            sessionAwareAccount.SessionChanged += OnSessionChanged;
        }
    }

    string? ISessionAware.Session { get; set; }

    public event EventHandler<string?>? SessionChanged;

    ISessionAware? _sessionAware;
    /// <inheritdoc/>
    public string? Session => GetSession();
    private string? GetSession()
    {
        if (_sessionAware is null)
        {
            _sessionAware = this;
        }

        return _sessionAware.Session;
    }

    /// <inheritdoc/>
    public void SetSession(string? session)
    {
        (this as ISessionAware).UpdateSession(session);
        (Account as ISessionAware)!.UpdateSession(session);
    }

    private void OnSessionChanged(object? sender, string? newSession)
    {
        SetSession(newSession);
    }
}
