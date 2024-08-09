using System.Runtime.Serialization;

namespace PinguApps.Appwrite.Shared.Enums;

/// <summary>
/// The type of second factor
/// </summary>
public enum SecondFactor
{
    /// <summary>
    /// Email 2fa
    /// </summary>
    [EnumMember(Value = "email")]
    Email,
    /// <summary>
    /// Phone 2fa
    /// </summary>
    [EnumMember(Value = "phone")]
    Phone,
    /// <summary>
    /// Authenticator App 2fa
    /// </summary>
    [EnumMember(Value = "totp")]
    Totp,
    /// <summary>
    /// 2fa Recovery Code
    /// </summary>
    [EnumMember(Value = "recoveryCode")]
    RecoveryCode
}
