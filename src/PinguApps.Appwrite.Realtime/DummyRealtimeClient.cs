using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Realtime.Models;

namespace PinguApps.Appwrite.Realtime;
internal class DummyRealtimeClient : IRealtimeClient
{
    public bool IsConnected => false;

    public Task DisconnectAsync() => Task.CompletedTask;

    public void SetSession(string? session)
    {
    }

    public IDisposable Subscribe<T>(List<string> channels, Action<RealtimeResponseEvent<T>> callback) => new DummyDisposable();

    public IDisposable Subscribe<T>(string channel, Action<RealtimeResponseEvent<T>> callback) => new DummyDisposable();

    private class DummyDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
