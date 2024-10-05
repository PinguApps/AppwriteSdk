namespace PinguApps.Appwrite.Shared;
public record Config(
    string Endpoint,
    string ProjectId,
    string? ApiKey = null
);
