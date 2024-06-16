using System.Runtime.Serialization;

namespace Appwrite.Client.Enums;
public enum TargetProviderType
{
    [EnumMember(Value = "email")]
    Email,
    [EnumMember(Value = "sms")]
    Sms,
    [EnumMember(Value = "push")]
    Push
}
