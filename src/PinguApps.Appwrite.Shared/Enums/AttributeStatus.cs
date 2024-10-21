using System.Runtime.Serialization;

namespace PinguApps.Appwrite.Shared.Enums;

/// <summary>
/// An Appwrite Status of an Attribute
/// </summary>
public enum AttributeStatus
{
    /// <summary>
    /// Available
    /// </summary>
    [EnumMember(Value = "available")]
    Available,

    /// <summary>
    /// Processing
    /// </summary>
    [EnumMember(Value = "processing")]
    Processing,

    /// <summary>
    /// Deleting
    /// </summary>
    [EnumMember(Value = "deleting")]
    Deleting,

    /// <summary>
    /// Stuck
    /// </summary>
    [EnumMember(Value = "stuck")]
    Stuck,

    /// <summary>
    /// Failed
    /// </summary>
    [EnumMember(Value = "failed")]
    Failed
}
