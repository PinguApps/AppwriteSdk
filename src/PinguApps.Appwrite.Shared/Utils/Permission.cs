using PinguApps.Appwrite.Shared.Enums;

namespace PinguApps.Appwrite.Shared.Utils;
public class Permission
{
    public PermissionType PermissionType { get; private set; }

    public Role Role { get; private set; }

    private Permission(PermissionType permissionType, Role role)
    {
        PermissionType = permissionType;
        Role = role;
    }

    public static Permission Read(Role role) => new(PermissionType.Read, role);

    public static Permission Write(Role role) => new(PermissionType.Write, role);

    public static Permission Create(Role role) => new(PermissionType.Create, role);

    public static Permission Update(Role role) => new(PermissionType.Update, role);

    public static Permission Delete(Role role) => new(PermissionType.Delete, role);
}
