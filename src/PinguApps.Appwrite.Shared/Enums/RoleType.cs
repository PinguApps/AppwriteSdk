namespace PinguApps.Appwrite.Shared.Enums;
public enum RoleType
{
    /// <summary>
    /// Grants access to anyone
    /// </summary>
    Any,
    /// <summary>
    /// Grants access to a specific user by user ID. You can optionally pass the verified or unverified string to target specific types of users
    /// </summary>
    User,
    /// <summary>
    /// Grants access to any authenticated or anonymous user. You can optionally pass the verified or unverified string to target specific types of users
    /// </summary>
    Users,
    /// <summary>
    /// Grants access to any guest user without a session. Authenticated users don't have access to this role
    /// </summary>
    Guests,
    /// <summary>
    /// Grants access to any member who possesses a specific role in a team. To gain access to this permission, the user must be a member of the specific team and have the given role assigned to them. Team roles can be assigned when inviting a user to become a team member
    /// </summary>
    Team,
    /// <summary>
    /// Grants access to a specific member of a team. When the member is removed from the team, they will no longer have access
    /// </summary>
    Member,
    /// <summary>
    /// Grants access to all accounts with a specific label ID. Once the label is removed from the user, they will no longer have access
    /// </summary>
    Label
}
