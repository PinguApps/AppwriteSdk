using System.Runtime.Serialization;

namespace PinguApps.Appwrite.Shared.Enums;

/// <summary>
/// An Appwrite OnDelete enum for Relationship Attributes
/// </summary>
public enum OnDelete
{
    /// <summary>
    /// Restrict
    /// </summary>
    [EnumMember(Value = "restrict")]
    Restrict,

    /// <summary>
    /// Cascade
    /// </summary>
    [EnumMember(Value = "cascade")]
    Cascade,

    /// <summary>
    /// Set null
    /// </summary>
    [EnumMember(Value = "setNull")]
    SetNull
}
