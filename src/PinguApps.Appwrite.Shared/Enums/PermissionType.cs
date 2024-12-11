namespace PinguApps.Appwrite.Shared.Enums;
public enum PermissionType
{
    /// <summary>
    /// Access to read a resource
    /// </summary>
    Read,
    /// <summary>
    /// Alias to grant create, update, and delete access for collections and buckets and update and delete access for documents and files
    /// </summary>
    Write,
    /// <summary>
    /// Access to create new resources. Does not apply to files or documents. Applying this type of access to files or documents results in an error
    /// </summary>
    Create,
    /// <summary>
    /// Access to change a resource, but not remove or create new resources. Does not apply to functions
    /// </summary>
    Update,
    /// <summary>
    /// Access to remove a resource. Does not apply to functions
    /// </summary>
    Delete
}
