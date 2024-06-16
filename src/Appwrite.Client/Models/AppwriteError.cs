namespace Appwrite.Client.Models;
public record AppwriteError(
    string Message,
    int Code,
    string Type,
    string Version
);
