namespace PinguApps.Appwrite.Shared.Tests;

public static class TestConstants
{
    public const string Endpoint = "https://localhost:12345/v1";

    public const string AppJson = "application/json";

    public const string ProjectId = "PROJECT_ID";

    public const string ApiKey = "API_KEY";

    public const string Session = "SESSION";

    public const string SdkName = ".NET";

    public const string SdkLanguage = "dotnet";

    public const string AppwriteResponseFormat = "1.6.0";

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

    public const string TokenResponse = """
        {
            "$id": "bb8ea5c16897e",
            "$createdAt": "2020-10-15T06:38:00.000+00:00",
            "userId": "5e5ea5c168bb8",
            "secret": "secret",
            "expire": "2020-10-15T06:38:00.000+00:00",
            "phrase": "Golden Fox"
        }
        """;

    public const string SessionResponse = """
        {
            "$id": "5e5ea5c16897e",
            "$createdAt": "2020-10-15T06:38:00.000+00:00",
            "$updatedAt": "2020-10-15T06:38:00.000+00:00",
            "userId": "5e5bb8c16897e",
            "expire": "2020-10-15T06:38:00.000+00:00",
            "provider": "email",
            "providerUid": "user@example.com",
            "providerAccessToken": "MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3",
            "providerAccessTokenExpiry": "2020-10-15T06:38:00.000+00:00",
            "providerRefreshToken": "MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3",
            "ip": "127.0.0.1",
            "osCode": "Mac",
            "osName": "Mac",
            "osVersion": "Mac",
            "clientType": "browser",
            "clientCode": "CM",
            "clientName": "Chrome Mobile iOS",
            "clientVersion": "84.0",
            "clientEngine": "WebKit",
            "clientEngineVersion": "605.1.15",
            "deviceName": "smartphone",
            "deviceBrand": "Google",
            "deviceModel": "Nexus 5",
            "countryCode": "US",
            "countryName": "United States",
            "current": true,
            "factors": [
                "email"
            ],
            "secret": "5e5bb8c16897e",
            "mfaUpdatedAt": "2020-10-15T06:38:00.000+00:00"
        }
        """;

    public const string JwtResponse = """
        {
            "jwt": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
        }
        """;

    public const string LogsListResponse = """
        {
            "total": 5,
            "logs": [
                {
                    "event": "account.sessions.create",
                    "userId": "610fc2f985ee0",
                    "userEmail": "john@appwrite.io",
                    "userName": "John Doe",
                    "mode": "admin",
                    "ip": "127.0.0.1",
                    "time": "2020-10-15T06:38:00.000+00:00",
                    "osCode": "Mac",
                    "osName": "Mac",
                    "osVersion": "Mac",
                    "clientType": "browser",
                    "clientCode": "CM",
                    "clientName": "Chrome Mobile iOS",
                    "clientVersion": "84.0",
                    "clientEngine": "WebKit",
                    "clientEngineVersion": "605.1.15",
                    "deviceName": "smartphone",
                    "deviceBrand": "Google",
                    "deviceModel": "Nexus 5",
                    "countryCode": "US",
                    "countryName": "United States"
                }
            ]
        }
        """;

    public const string MfaTypeResponse = """
        {
            "secret": "The_Secret",
            "uri": "otpauth://totp/Appwrite%20Test%3Apingu%40appwrite.com?issuer=Appwrite%20Test&secret=The_Secret"
        }
        """;

    public const string MfaChallengeResponse = """
        {
            "$id": "bb8ea5c16897e",
            "$createdAt": "2020-10-15T06:38:00.000+00:00",
            "userId": "5e5ea5c168bb8",
            "expire": "2020-10-15T06:38:00.000+00:00"
        }
        """;

    public const string MfaFactorsResponse = """
        {
            "totp": true,
            "phone": true,
            "email": true,
            "recoveryCode": true
        }
        """;

    public const string MfaRecoveryCodesResponse = """
        {
            "recoveryCodes": [
                "a3kf0-s0cl2",
                "s0co1-as98s"
            ]
        }
        """;

    public const string SessionsListResponse = """
        {
            "total": 5,
            "sessions": [
                {
                    "$id": "5e5ea5c16897e",
                    "$createdAt": "2020-10-15T06:38:00.000+00:00",
                    "$updatedAt": "2020-10-15T06:38:00.000+00:00",
                    "userId": "5e5bb8c16897e",
                    "expire": "2020-10-15T06:38:00.000+00:00",
                    "provider": "email",
                    "providerUid": "user@example.com",
                    "providerAccessToken": "MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3",
                    "providerAccessTokenExpiry": "2020-10-15T06:38:00.000+00:00",
                    "providerRefreshToken": "MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3",
                    "ip": "127.0.0.1",
                    "osCode": "Mac",
                    "osName": "Mac",
                    "osVersion": "Mac",
                    "clientType": "browser",
                    "clientCode": "CM",
                    "clientName": "Chrome Mobile iOS",
                    "clientVersion": "84.0",
                    "clientEngine": "WebKit",
                    "clientEngineVersion": "605.1.15",
                    "deviceName": "smartphone",
                    "deviceBrand": "Google",
                    "deviceModel": "Nexus 5",
                    "countryCode": "US",
                    "countryName": "United States",
                    "current": true,
                    "factors": [
                        "email"
                    ],
                    "secret": "5e5bb8c16897e",
                    "mfaUpdatedAt": "2020-10-15T06:38:00.000+00:00"
                }
            ]
        }
        """;

    public const string IdentitiesListResponse = """
        {
            "total": 5,
            "identities": [
                {
                    "$id": "5e5ea5c16897e",
                    "$createdAt": "2020-10-15T06:38:00.000+00:00",
                    "$updatedAt": "2020-10-15T06:38:00.000+00:00",
                    "userId": "5e5bb8c16897e",
                    "provider": "email",
                    "providerUid": "5e5bb8c16897e",
                    "providerEmail": "user@example.com",
                    "providerAccessToken": "MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3",
                    "providerAccessTokenExpiry": "2020-10-15T06:38:00.000+00:00",
                    "providerRefreshToken": "MTQ0NjJkZmQ5OTM2NDE1ZTZjNGZmZjI3"
                }
            ]
        }
        """;

    public const string UsersListResponse = """
                {
            "total": 5,
            "users": [
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
            ]
        }
        """;

    public const string MembershipsListResponse = """
        {
            "total": 5,
            "memberships": [
                {
                    "$id": "5e5ea5c16897e",
                    "$createdAt": "2020-10-15T06:38:00.000+00:00",
                    "$updatedAt": "2020-10-15T06:38:00.000+00:00",
                    "userId": "5e5ea5c16897e",
                    "userName": "John Doe",
                    "userEmail": "john@appwrite.io",
                    "teamId": "5e5ea5c16897e",
                    "teamName": "VIP",
                    "invited": "2020-10-15T06:38:00.000+00:00",
                    "joined": "2020-10-15T06:38:00.000+00:00",
                    "confirm": false,
                    "mfa": false,
                    "roles": [
                        "owner"
                    ]
                }
            ]
        }
        """;

    public const string MembershipResponse = """
        {
            "$id": "5e5ea5c16897e",
            "$createdAt": "2020-10-15T06:38:00.000+00:00",
            "$updatedAt": "2020-10-15T06:38:00.000+00:00",
            "userId": "5e5ea5c16897e",
            "userName": "John Doe",
            "userEmail": "john@appwrite.io",
            "teamId": "5e5ea5c16897e",
            "teamName": "VIP",
            "invited": "2020-10-15T06:38:00.000+00:00",
            "joined": "2020-10-15T06:38:00.000+00:00",
            "confirm": false,
            "mfa": false,
            "roles": [
                "owner"
            ]
        }
        """;

    public const string TargetListResponse = """
        {
            "total": 5,
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
            ]
        }
        """;

    public const string TargetResponse = """
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
        """;

    public const string TeamResponse = """
        {
            "$id": "5e5ea5c16897e",
            "$createdAt": "2020-10-15T06:38:00.000+00:00",
            "$updatedAt": "2020-10-15T06:38:00.000+00:00",
            "name": "VIP",
            "total": 7,
            "prefs": {}
        }
        """;

    public const string TeamsListResponse = """
        {
            "total": 5,
            "teams": [
                {
                    "$id": "5e5ea5c16897e",
                    "$createdAt": "2020-10-15T06:38:00.000+00:00",
                    "$updatedAt": "2020-10-15T06:38:00.000+00:00",
                    "name": "VIP",
                    "total": 7,
                    "prefs": {}
                }
            ]
        }
        """;

    public const string DatabaseResponse = """
        {
            "$id": "5e5ea5c16897e",
            "name": "My Database",
            "$createdAt": "2020-10-15T06:38:00.000+00:00",
            "$updatedAt": "2020-10-15T06:38:00.000+00:00",
            "enabled": false
        }
        """;

    public const string DatabasesListResponse = """
        {
            "total": 5,
            "databases": [
                {
                    "$id": "5e5ea5c16897e",
                    "name": "My Database",
                    "$createdAt": "2020-10-15T06:38:00.000+00:00",
                    "$updatedAt": "2020-10-15T06:38:00.000+00:00",
                    "enabled": false
                }
            ]
        }
        """;

    public const string AttributesListResponse = """
        {
            "total": 5,
            "attributes": [
                {
                    "key": "isEnabled",
                    "type": "boolean",
                    "status": "available",
                    "error": "string",
                    "required": true,
                    "array": false,
                    "$createdAt": "2020-10-15T06:38:00.000+00:00",
                    "$updatedAt": "2020-10-15T06:38:00.000+00:00",
                    "default": false
                }
            ]
        }
        """;

    public const string AttributeBooleanResponse = """
        {
            "key": "isEnabled",
            "type": "boolean",
            "status": "available",
            "error": "string",
            "required": true,
            "array": false,
            "$createdAt": "2020-10-15T06:38:00.000+00:00",
            "$updatedAt": "2020-10-15T06:38:00.000+00:00",
            "default": false
        }
        """;

    public const string AttributeDatetimeResponse = """
        {
            "key": "birthDay",
            "type": "datetime",
            "status": "available",
            "error": "string",
            "required": true,
            "array": false,
            "$createdAt": "2020-10-15T06:38:00.000+00:00",
            "$updatedAt": "2020-10-15T06:38:00.000+00:00",
            "format": "datetime",
            "default": "2020-10-15T06:38:00.000+00:00"
        }
        """;
}
