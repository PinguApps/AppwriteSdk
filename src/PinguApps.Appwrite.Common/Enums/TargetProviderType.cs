using System.Runtime.Serialization;

namespace PinguApps.Appwrite.Shared.Enums;
public enum TargetProviderType
{
    [EnumMember(Value = "email")]
    Email,
    [EnumMember(Value = "sms")]
    Sms,
    [EnumMember(Value = "push")]
    Push
}
