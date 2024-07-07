using System.Runtime.Serialization;

namespace PinguApps.Appwrite.Shared.Enums;

/// <summary>
/// The type of target
/// </summary>
public enum TargetProviderType
{
    /// <summary>
    /// Email
    /// </summary>
    [EnumMember(Value = "email")]
    Email,
    /// <summary>
    /// Sms
    /// </summary>
    [EnumMember(Value = "sms")]
    Sms,
    /// <summary>
    /// Push
    /// </summary>
    [EnumMember(Value = "push")]
    Push
}
