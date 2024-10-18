using System;

namespace PinguApps.Appwrite.Client.Clients;
public abstract class SessionAwareClientBase : ISessionAware
{
    string? ISessionAware.Session { get; set; }

    /// <summary>
    /// Get the current session
    /// </summary>
    public string? Session => GetCurrentSession();

    protected string? GetCurrentSession()
    {
        return ((ISessionAware)this).Session;
    }

    public string GetCurrentSessionOrThrow()
    {
        return GetCurrentSession() ?? throw new Exception(ISessionAware.SessionExceptionMessage);
    }
}
