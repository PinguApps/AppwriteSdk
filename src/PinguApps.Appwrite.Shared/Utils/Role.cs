using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;

namespace PinguApps.Appwrite.Shared.Utils;

/// <summary>
/// Helper class to create Role definitions. Works in tandem with <see cref="Permission"/>
/// </summary>
[JsonConverter(typeof(RoleJsonConverter))]
public class Role
{
    /// <summary>
    /// The type of role
    /// </summary>
    public RoleType RoleType { get; private set; }

    /// <summary>
    /// The Id of the team, user or member
    /// </summary>
    public string? Id { get; private set; }

    /// <summary>
    /// The verification status of a user group
    /// </summary>
    public RoleStatus? Status { get; private set; }

    /// <summary>
    /// The role of team members
    /// </summary>
    public string? TeamRole { get; private set; }

    /// <summary>
    /// The user label
    /// </summary>
    public string? LabelName { get; private set; }

    private Role(RoleType roleType)
    {
        RoleType = roleType;
    }

    private Role(RoleType roleType, string id) : this(roleType)
    {
        Id = id;
    }

    private Role(RoleType roleType, string id, RoleStatus status) : this(roleType, id)
    {
        Status = status;
    }

    private Role(RoleType roleType, RoleStatus status) : this(roleType)
    {
        Status = status;
    }

    private Role(RoleType roleType, string id, string teamRole) : this(roleType, id)
    {
        TeamRole = teamRole;
    }

    /// <summary>
    /// Creates a role defining anyone
    /// </summary>
    /// <returns>The role</returns>
    public static Role Any() => new(RoleType.Any);

    /// <summary>
    /// Creates a role defining a specific user
    /// </summary>
    /// <returns>The role</returns>
    public static Role User(string id) => new(RoleType.User, id);

    /// <summary>
    /// Creates a role defining a specific user, given their verification status
    /// </summary>
    /// <returns>The role</returns>
    public static Role User(string id, RoleStatus status) => new(RoleType.User, id, status);

    /// <summary>
    /// Creates a role defining all users
    /// </summary>
    /// <returns>The role</returns>
    public static Role Users() => new(RoleType.Users);

    /// <summary>
    /// Creates a role defining all users, given their verification status
    /// </summary>
    /// <returns>The role</returns>
    public static Role Users(RoleStatus status) => new(RoleType.Users, status);

    /// <summary>
    /// Creates a role defining all guests
    /// </summary>
    /// <returns>The role</returns>
    public static Role Guests() => new(RoleType.Guests);

    /// <summary>
    /// Creates a role defining anyone belonging to the specified team
    /// </summary>
    /// <returns>The role</returns>
    public static Role Team(string id) => new(RoleType.Team, id);

    /// <summary>
    /// Creates a role defining anyone belonging to the specified team, and posessing the specified role within the team
    /// </summary>
    /// <returns>The role</returns>
    public static Role Team(string id, string teamRole) => new(RoleType.Team, id, teamRole);

    /// <summary>
    /// Creates a role defining anyone who is a member of the specified team
    /// </summary>
    /// <returns>The role</returns>
    public static Role Member(string id) => new(RoleType.Member, id);

    /// <summary>
    /// Creates a role defining anyone with the specified label
    /// </summary>
    /// <returns>The role</returns>
    public static Role Label(string label) => new(RoleType.Label)
    {
        LabelName = label
    };
}
