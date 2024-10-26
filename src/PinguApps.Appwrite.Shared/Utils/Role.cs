using PinguApps.Appwrite.Shared.Enums;

namespace PinguApps.Appwrite.Shared.Utils;
public class Role
{
    public RoleType RoleType { get; private set; }
    public string? Id { get; private set; }
    public RoleStatus? Status { get; private set; }
    public string? TeamRole { get; private set; }
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

    public static Role Any() => new(RoleType.Any);

    public static Role User(string id) => new(RoleType.User, id);

    public static Role User(string id, RoleStatus status) => new(RoleType.User, id, status);

    public static Role Users() => new(RoleType.Users);

    public static Role Users(RoleStatus status) => new(RoleType.Users, status);

    public static Role Guests() => new(RoleType.Guests);

    public static Role Team(string id) => new(RoleType.Team, id);

    public static Role Team(string id, string teamRole) => new(RoleType.Team, id, teamRole);

    public static Role Member(string id) => new(RoleType.Member, id);

    public static Role Label(string label) => new(RoleType.Label)
    {
        LabelName = label
    };
}
