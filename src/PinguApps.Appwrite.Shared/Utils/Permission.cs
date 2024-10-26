using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Enums;

namespace PinguApps.Appwrite.Shared.Utils;

/// <summary>
/// Helper class to create permission definitions
/// </summary>
[JsonConverter(typeof(PermissionJsonConverter))]
public class Permission
{
    /// <summary>
    /// The type of the permission - What access is being granted to the role(s)
    /// </summary>
    public PermissionType PermissionType { get; private set; }

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
    public string? Label { get; private set; }

    // Private constructor - can only be created through the builder
    private Permission(PermissionType permissionType, RoleType roleType, string? id = null, RoleStatus? status = null,
        string? teamRole = null, string? label = null)
    {
        PermissionType = permissionType;
        RoleType = roleType;
        Id = id;
        Status = status;
        TeamRole = teamRole;
        Label = label;
    }

    /// <summary>
    /// Access to read a resource
    /// </summary>
    public static PermissionBuilder Read() => new(PermissionType.Read);

    /// <summary>
    /// Alias to grant create, update, and delete access for collections and buckets and update and delete access for documents and files
    /// </summary>
    public static PermissionBuilder Write() => new(PermissionType.Write);

    /// <summary>
    /// Access to create new resources. Does not apply to files or documents. Applying this type of access to files or documents results in an error
    /// </summary>
    public static PermissionBuilder Create() => new(PermissionType.Create);

    /// <summary>
    /// Access to change a resource, but not remove or create new resources. Does not apply to functions
    /// </summary>
    public static PermissionBuilder Update() => new(PermissionType.Update);

    /// <summary>
    /// Access to remove a resource. Does not apply to functions
    /// </summary>
    public static PermissionBuilder Delete() => new(PermissionType.Delete);

    public class PermissionBuilder
    {
        private readonly PermissionType _permissionType;

        internal PermissionBuilder(PermissionType permissionType)
        {
            _permissionType = permissionType;
        }

        /// <summary>
        /// Grants access to anyone
        /// </summary>
        public Permission Any() => new(_permissionType, RoleType.Any);

        /// <summary>
        /// Grants access to any authenticated or anonymous user
        /// </summary>
        public Permission Users() => new(_permissionType, RoleType.Users);

        /// <summary>
        /// Grants access to any authenticated or anonymous user. You can optionally pass the verified or unverified string to target specific types of users
        /// </summary>
        public Permission Users(RoleStatus status) => new(_permissionType, RoleType.Users, status: status);

        /// <summary>
        /// Grants access to a specific user by user ID
        /// </summary>
        public Permission User(string userId) => new(_permissionType, RoleType.User, id: userId);

        /// <summary>
        /// Grants access to a specific user by user ID. You can optionally pass the verified or unverified string to target specific types of users
        /// </summary>
        public Permission User(string userId, RoleStatus status) => new(_permissionType, RoleType.User, id: userId, status: status);

        /// <summary>
        /// Grants access to any guest user without a session. Authenticated users don't have access to this role
        /// </summary>
        public Permission Guests() => new(_permissionType, RoleType.Guests);

        /// <summary>
        /// Grants access to any member of the specific team. To gain access to this permission, the user must be the team creator (owner), or receive and accept an invitation to join this team
        /// </summary>
        public Permission Team(string teamId) => new(_permissionType, RoleType.Team, id: teamId);

        /// <summary>
        /// Grants access to any member who possesses a specific role in a team. To gain access to this permission, the user must be a member of the specific team and have the given role assigned to them. Team roles can be assigned when inviting a user to become a team member
        /// </summary>
        public Permission Team(string teamId, string teamRole) => new(_permissionType, RoleType.Team, id: teamId, teamRole: teamRole);

        /// <summary>
        /// Grants access to a specific member of a team. When the member is removed from the team, they will no longer have access
        /// </summary>
        public Permission Member(string memberId) => new(_permissionType, RoleType.Member, id: memberId);

        /// <summary>
        /// Grants access to all accounts with a specific label ID. Once the label is removed from the user, they will no longer have access. <see href="https://appwrite.io/docs/products/auth/labels">Learn more about labels</see>.
        /// </summary>
        public Permission Label(string label) => new(_permissionType, RoleType.Label, label: label);
    }

}
