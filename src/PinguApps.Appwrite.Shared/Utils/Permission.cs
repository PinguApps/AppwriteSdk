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
    /// The role(s) to grant the permissions to
    /// </summary>
    public Role Role { get; private set; }

    private Permission(PermissionType permissionType, Role role)
    {
        PermissionType = permissionType;
        Role = role;
    }

    /// <summary>
    /// Creates Read pemission for the given role
    /// </summary>
    /// <param name="role">The role to grant this permission level to</param>
    /// <returns>The permission</returns>
    public static Permission Read(Role role) => new(PermissionType.Read, role);

    /// <summary>
    /// Creates Write pemission for the given role
    /// </summary>
    /// <param name="role">The role to grant this permission level to</param>
    /// <returns>The permission</returns>
    public static Permission Write(Role role) => new(PermissionType.Write, role);

    /// <summary>
    /// Creates Create pemission for the given role
    /// </summary>
    /// <param name="role">The role to grant this permission level to</param>
    /// <returns>The permission</returns>
    public static Permission Create(Role role) => new(PermissionType.Create, role);

    /// <summary>
    /// Creates Udpate pemission for the given role
    /// </summary>
    /// <param name="role">The role to grant this permission level to</param>
    /// <returns>The permission</returns>
    public static Permission Update(Role role) => new(PermissionType.Update, role);

    /// <summary>
    /// Creates Delete pemission for the given role
    /// </summary>
    /// <param name="role">The role to grant this permission level to</param>
    /// <returns>The permission</returns>
    public static Permission Delete(Role role) => new(PermissionType.Delete, role);
}
