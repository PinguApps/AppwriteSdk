namespace PinguApps.Appwrite.Server.Tests;
internal static class Constants
{
    internal const string Endpoint = "https://localhost:12345/v1";

    internal const string AppJson = "application/json";

    internal const string AppwriteError = """
        {
            "message": "Generic appwrite failure.",
            "code": 400,
            "type": "general_failure",
            "version": "1.5.7"
        }
        """;

    internal const string UserResponse = """
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
            "prefs": {},
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
}
