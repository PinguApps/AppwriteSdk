using System.Runtime.Serialization;

namespace PinguApps.Appwrite.Shared.Enums;

/// <summary>
/// An Appwrite Side enum for Relationship Attributes
/// </summary>
public enum RelationshipSide
{
    /// <summary>
    /// Parent
    /// </summary>
    [EnumMember(Value = "parent")]
    Parent,

    /// <summary>
    /// Child
    /// </summary>
    [EnumMember(Value = "child")]
    Child
}
