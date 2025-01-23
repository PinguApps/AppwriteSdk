using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Realtime.Models;

namespace PinguApps.Appwrite.Realtime;
public interface IRealtimeClient
{
    bool IsConnected { get; }
    Task DisconnectAsync();
    void SetSession(string? session);
    IDisposable Subscribe<T>(List<string> channels, Action<RealtimeResponseEvent<T>> callback);
    IDisposable Subscribe<T>(string channel, Action<RealtimeResponseEvent<T>> callback);
}
