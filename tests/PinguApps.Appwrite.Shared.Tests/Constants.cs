namespace PinguApps.Appwrite.Shared.Tests;

public static class Constants
{
    public const string Endpoint = "https://localhost:12345/v1";

    public const string AppJson = "application/json";

    public const string ProjectId = "PROJECT_ID";

    public const string ApiKey = "API_KEY";

    public const string Session = "SESSION";

    public const string SdkName = ".NET";

    public const string SdkLanguage = "dotnet";

    public const string SdkVersion = "0.0.1";

    public const string AppwriteResponseFormat = "1.5.0";

    public const string AppwriteError = """
        {
            "message": "Generic appwrite failure.",
            "code": 400,
            "type": "general_failure",
            "version": "1.5.7"
        }
        """;

    public const string UserResponse = """
        {
            "$id": "5e5ea5c16897e",
            "$createdAt": "2020-10-15T06:38:00.000+00:00",
            "$updatedAt": "2020-10-15T06:38:00.000+00:00",
            "name": "John Doe",
            "password": "$argon2id$v=19$m=2048,t=4,p=3$aUZjLnliVWRINmFNTWMudg$5S+x+7uA31xFnrHFT47yFwcJeaP0w92L/4LdgrVRXxE",
            "hash": "argon2",
            "hashOptions": {
                "type": "argon2",
                "memoryCost": 65536,
                "timeCost": 4,
                "threads": 3
            },
            "registration": "2020-10-15T06:38:00.000+00:00",
            "status": true,
            "labels": [
                "vip"
            ],
            "passwordUpdate": "2020-10-15T06:38:00.000+00:00",
            "email": "john@appwrite.io",
            "phone": "+4930901820",
            "emailVerification": true,
            "phoneVerification": true,
            "mfa": true,
            "prefs": {
                "pref1": "val1"
            },
            "targets": [
                {
                    "$id": "259125845563242502",
                    "$createdAt": "2020-10-15T06:38:00.000+00:00",
                    "$updatedAt": "2020-10-15T06:38:00.000+00:00",
                    "name": "Aegon apple token",
                    "userId": "259125845563242502",
                    "providerId": "259125845563242502",
                    "providerType": "email",
                    "identifier": "token"
                }
            ],
            "accessedAt": "2020-10-15T06:38:00.000+00:00"
        }
        """;

    public const string PreferencesResponse = """
        {
            "abc": "123",
            "def": "456"
        }
        """;
}
