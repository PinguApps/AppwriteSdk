namespace PinguApps.Appwrite.Shared;

/// <summary>
/// An internal error, indicating a fault within the SDK rather than Appwrite
/// </summary>
/// <param name="Message">The message of any thrown exception</param>
public record InternalError(
    string Message
);
