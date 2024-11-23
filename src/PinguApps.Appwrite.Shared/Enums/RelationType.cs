using System.Runtime.Serialization;

namespace PinguApps.Appwrite.Shared.Enums;

/// <summary>
/// An Appwrite rerlation type for relationship attributes
/// </summary>
public enum RelationType
{
    /// <summary>
    /// One to one
    /// </summary>
    [EnumMember(Value = "oneToOne")]
    OneToOne,

    /// <summary>
    /// One to many
    /// </summary>
    [EnumMember(Value = "oneToMany")]
    OneToMany,

    /// <summary>
    /// Many to one
    /// </summary>
    [EnumMember(Value = "manyToOne")]
    ManyToOne,

    /// <summary>
    /// Many to many
    /// </summary>
    [EnumMember(Value = "manyToMany")]
    ManyToMany
}
