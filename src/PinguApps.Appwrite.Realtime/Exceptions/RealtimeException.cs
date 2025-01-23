using System;

namespace PinguApps.Appwrite.Realtime.Exceptions;
public class RealtimeException : Exception
{
    public int Code { get; }
    public RealtimeException(string message, int code) : base(message) => Code = code;
}
