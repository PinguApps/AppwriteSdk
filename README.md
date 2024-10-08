# Appwrite SDK
This repository contains the source to both the Client and Server .net implimentation for Appwrite API. This is not a first party SDK, rather a third party SDK.

[![Client Version](https://img.shields.io/nuget/v/PinguApps.Appwrite.Client?logo=nuget&style=for-the-badge&label=Client%20Version)](https://www.nuget.org/packages/PinguApps.Appwrite.Client) [![Client Downloads](https://img.shields.io/nuget/dt/PinguApps.Appwrite.Client?style=for-the-badge&logo=nuget&label=Client%20Downloads)](https://www.nuget.org/packages/PinguApps.Appwrite.Client) [![Server Version](https://img.shields.io/nuget/v/PinguApps.Appwrite.Server?logo=nuget&style=for-the-badge&label=Server%20Version)](https://www.nuget.org/packages/PinguApps.Appwrite.Server) [![Server Downloads](https://img.shields.io/nuget/dt/PinguApps.Appwrite.Server?style=for-the-badge&logo=nuget&label=Server%20Downloads)](https://www.nuget.org/packages/PinguApps.Appwrite.Server) [![GitHub Repo stars](https://img.shields.io/github/stars/PinguApps/AppwriteSdk?style=for-the-badge&logo=github)](https://github.com/PinguApps/AppwriteSdk/stargazers) [![GitHub Actions Workflow Status](https://img.shields.io/github/actions/workflow/status/PinguApps/AppwriteSdk/main.yml?style=for-the-badge&logo=github)](https://github.com/PinguApps/AppwriteSdk/actions/workflows/main.yml) [![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/PinguApps/AppwriteSdk?style=for-the-badge&logo=codefactor)](https://www.codefactor.io/repository/github/pinguapps/AppwriteSdk)

![Repobeats Analytics](https://repobeats.axiom.co/api/embed/1ec2e55e97fb4516682f5e66feba33976870ab32.svg)

## 🚧 Work in Progress
This is a work in progress. There are 2 SDK's - one for client and another for server.

## 🔧 Installation
It is recommended to install just the client SDK into client-side projects, and both the client and server SDK into server side projects.

### Client SDK
```sh
Install-Package PinguApps.Appwrite.Client
```
or in the Nuget package manager, search for `PinguApps.Appwrite.Client` (ensure you are searching for prerelease versions)
### Server SDK
```sh
Install-Package PinguApps.Appwrite.Server
```
or in the Nuget package manager, search for `PinguApps.Appwrite.Server`

## 🚀 Usage
Once the package(s) are installed, you will need to add everything to your DI container. Thankfully, there's an extension method making this simple.

### DI Container
#### Client SDK
There are 2 extension methods for the client SDK. One intended for client side usage, and the other for server side usage. The only difference is the lifetimes used in the DI container.

For client side:
```csharp
services.AddAppwriteClient("Project_Id");
```

For Server side:

```csharp
services.AddAppwriteClientForServer("Project_Id");
```

> This will assume that you are using Appwrite in the cloud. If you are not, then you can specify your endpoint as the second parameter, which is optional. Additionally, for finer control, you can specify your own `RefitSettings` as the third parameter.

#### Server SDK
```csharp
services.AddAppwriteServer("Project_Id", "Api_Key");
```

> This will assume that you are using Appwrite in the cloud. If you are not, then you can specify your endpoint as the second parameter, which is optional. Additionally, for finer control, you can specify your own `RefitSettings` as the third parameter.

### Injecting
To inject the SDK, you will need to request either an `IAppwriteClient` or `IAppwriteServer`, depending on which you are working with and need.

```csharp
public class App
{
    private readonly IAppwriteClient _client;
    private readonly IAppwriteServer _server;

    public App(IAppwriteClient client, IAppwriteServer server)
    {
        _client = client;
        _server = server;
    }
}
```

### Sessions (Client only)
The Client SDK will manage sessions for you. You can set the current session with:
```casharp
_client.SetSession("SessionToken");
```

### Making Calls
Both SDK's are split up into sections, matching the [Appwrite Docs](https://appwrite.io/docs/references).

To make a call to get the current logged in account on the client SDK, you can do this with:
```csharp
var user = await _client.Account.Get();
```

To create an account with the Server SDK, it might look like this:
```csharp
var request = new CreateAccountRequest
{
    Email = "pingu@example.com",
    Password = "MySuperSecretPassword",
    Name = "Pingu"
};

var user = await _server.Account.Create(request);
```

### Handling the result
The result object is made up of a `Result` property, as well as some `bool`'s to assist in determining the success or failure. The `Result` Property will be one of 3 different types, depending on what happened.

All following examples will be based on the following preceeding them:
```csharp
var userResponse = await _client.Account.Get();
```

We can determine if the call we made was successful or not by checking `userResponse.Success`. If this is true, the `Result` will be an object of the type returned from the API, in this case it will be of type `User`.

If `userResponse.Success` is false, then `userResponse.IsError` will be true (which we could also use to check the inverse).

If we have errored, then there might be 2 sources for the error. One would be Appwrite throwing an error, and the other would be internal - within the SDK. This could be a bug with the SDK, or invalid input provided to it.

If `userResponse.IsAppwriteError` is true, then `Result` will be of type `AppwriteError`.

If `userResponse.IsInternalError` is true, then `Result` will be of type `InternalError`.

We can switch on the result type, allowing us to perform different logic based on the success status.

```csharp
userResponse.Result.Switch(
    account => Console.WriteLine(account.Email),
    appwriteError => Console.WriteLine(appwriteError.Message),
    internalError => Console.WriteLine(internalError.Message)
);
```

We can also pull out the known type of the response:

```csharp
if(userResponse.Success)
{
    var email = userResponse.Result.AsT0.Email;
}
```

Finally, we can return something different depending on what type it is:

```csharp
string emailAddressOrErrorMessage = userResponse.Result.Match(
    account => account.Email,
    appwriteError => appwriteError.Message,
    internalError => internalError.Message
);
```

## ⌛ Progress
![Server & Client - 73 / 291](https://img.shields.io/badge/Server_&_Client-73%20%2F%20291-red?style=for-the-badge)

![Server - 29 / 201](https://img.shields.io/badge/Server-29%20%2F%20201-red?style=for-the-badge)

![Client - 44 / 90](https://img.shields.io/badge/Client-44%20%2F%2090-gold?style=for-the-badge)

### 🔑 Key
| Icon | Definition |
|:-:|:-:|
| ✅ | The endpoint is implemented for the given SDK type (client or server) |
| ⬛ | The endpoint is not yet implemented for the given SDK type (client or server), but will be |
| ❌ | There is currently no intention to implement the endpoint for the given SDK type (client or server) |

### Account
![Account - 55 / 55](https://img.shields.io/badge/Account-55%20%2F%2055-forestgreen?style=for-the-badge)

| Endpoint | Client | Server | Notes |
|:-:|:-:|:-:|:-:|
| [Get Account](https://appwrite.io/docs/references/1.6.x/client-rest/account#get) | ✅ | ❌ |  |
| [Create Account](https://appwrite.io/docs/references/1.6.x/client-rest/account#create) | ✅ | ✅ |  |
| [Update Email](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateEmail) | ✅ | ❌ |  |
| [List Identities](https://appwrite.io/docs/references/1.6.x/client-rest/account#listIdentities) | ✅ | ❌ |  |
| [Delete Identity](https://appwrite.io/docs/references/1.6.x/client-rest/account#deleteIdentity) | ✅ | ❌ |  |
| [Create JWT](https://appwrite.io/docs/references/1.6.x/client-rest/account#createJWT) | ✅ | ❌ |  |
| [List Logs](https://appwrite.io/docs/references/1.6.x/client-rest/account#listLogs) | ✅ | ❌ |  |
| [Update MFA](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateMFA) | ✅ | ❌ |  |
| [Add Authenticator](https://appwrite.io/docs/references/1.6.x/client-rest/account#createMfaAuthenticator) | ✅ | ❌ |  |
| [Verify Authenticator](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateMfaAuthenticator) | ✅ | ❌ |  |
| [Delete Authenticator](https://appwrite.io/docs/references/1.6.x/client-rest/account#deleteMfaAuthenticator) | ✅ | ❌ |  |
| [Create 2FA Challenge](https://appwrite.io/docs/references/1.6.x/client-rest/account#createMfaChallenge) | ✅ | ❌ |  |
| [Create MFA Challenge (confirmation)](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateMfaChallenge) | ✅ | ❌ |  |
| [List Factors](https://appwrite.io/docs/references/1.6.x/client-rest/account#listMfaFactors) | ✅ | ❌ |  |
| [Get MFA Recovery Codes](https://appwrite.io/docs/references/1.6.x/client-rest/account#getMfaRecoveryCodes) | ✅ | ❌ |  |
| [Create MFA Recovery Codes](https://appwrite.io/docs/references/1.6.x/client-rest/account#createMfaRecoveryCodes) | ✅ | ❌ |  |
| [Regenerate MFA Recovery Codes](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateMfaRecoveryCodes) | ✅ | ❌ |  |
| [Update Name](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateName) | ✅ | ❌ |  |
| [Update Password](https://appwrite.io/docs/references/1.6.x/client-rest/account#updatePassword) | ✅ | ❌ |  |
| [Update Phone](https://appwrite.io/docs/references/1.6.x/client-rest/account#updatePhone) | ✅ | ❌ |  |
| [Get Account Preferences](https://appwrite.io/docs/references/1.6.x/client-rest/account#getPrefs) | ✅ | ❌ |  |
| [Update Preferences](https://appwrite.io/docs/references/1.6.x/client-rest/account#updatePrefs) | ✅ | ❌ |  |
| [Create Password Recovery](https://appwrite.io/docs/references/1.6.x/client-rest/account#createRecovery) | ✅ | ❌ |  |
| [Create Password Recovery (Confirmation)](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateRecovery) | ✅ | ❌ |  |
| [List Sessions](https://appwrite.io/docs/references/1.6.x/client-rest/account#listSessions) | ✅ | ❌ |  |
| [Delete Sessions](https://appwrite.io/docs/references/1.6.x/client-rest/account#deleteSessions) | ✅ | ❌ |  |
| [Create Anonymous Session](https://appwrite.io/docs/references/1.6.x/client-rest/account#createAnonymousSession) | ✅ | ✅ |  |
| [Create Email Password Session](https://appwrite.io/docs/references/1.6.x/client-rest/account#createEmailPasswordSession) | ✅ | ✅ |  |
| [Update Magic URL Session](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateMagicURLSession) | ✅ | ✅ |  |
| [Create OAuth2 Session](https://appwrite.io/docs/references/1.6.x/client-rest/account#createOAuth2Session) | ✅ | ✅ |  |
| [Update Phone Session](https://appwrite.io/docs/references/1.6.x/client-rest/account#updatePhoneSession) | ✅ | ✅ |  |
| [Create Session](https://appwrite.io/docs/references/1.6.x/client-rest/account#createSession) | ✅ | ✅ |  |
| [Get Session](https://appwrite.io/docs/references/1.6.x/client-rest/account#getSession) | ✅ | ❌ |  |
| [Update Session](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateSession) | ✅ | ❌ |  |
| [Delete Session](https://appwrite.io/docs/references/1.6.x/client-rest/account#deleteSession) | ✅ | ❌ |  |
| [Update Status](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateStatus) | ✅ | ❌ |  |
| [Create Push Target](https://appwrite.io/docs/references/1.6.x/client-rest/account#createPushTarget) | ❌ | ❌ | Appwrite functionality broken - Use Users API instead. |
| [Update Push Target](https://appwrite.io/docs/references/1.6.x/client-rest/account#updatePushTarget) | ❌ | ❌ | Appwrite functionality broken - Use Users API instead. |
| [Delete Push Target](https://appwrite.io/docs/references/1.6.x/client-rest/account#deletePushTarget) | ❌ | ❌ | Appwrite functionality broken - Use Users API instead. |
| [Create Email Token (OTP)](https://appwrite.io/docs/references/1.6.x/client-rest/account#createEmailToken) | ✅ | ✅ |  |
| [Create Magic URL Token](https://appwrite.io/docs/references/1.6.x/client-rest/account#createMagicURLToken) | ✅ | ✅ |  |
| [Create OAuth2 Token](https://appwrite.io/docs/references/1.6.x/client-rest/account#createOAuth2Token) | ✅| ✅ |  |
| [Create Phone Token](https://appwrite.io/docs/references/1.6.x/client-rest/account#createPhoneToken) | ✅ | ✅ |  |
| [Create Email Verification](https://appwrite.io/docs/references/1.6.x/client-rest/account#createVerification) | ✅ | ❌ |  |
| [Create Email Verification (Confirmation)](https://appwrite.io/docs/references/1.6.x/client-rest/account#updateVerification) | ✅ | ❌ |  |
| [Create Phone Verification](https://appwrite.io/docs/references/1.6.x/client-rest/account#createPhoneVerification) | ✅ | ❌ |  |
| [Create Phone Verification (Confirmation)](https://appwrite.io/docs/references/1.6.x/client-rest/account#updatePhoneVerification) | ✅ | ❌ |  |

### Users
![Account - 18 / 41](https://img.shields.io/badge/Users-18%20%2F%2041-gold?style=for-the-badge)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Users](https://appwrite.io/docs/references/1.6.x/server-rest/users#list) | ❌ | ✅ |
| [Create User](https://appwrite.io/docs/references/1.6.x/server-rest/users#create) | ❌ | ✅ |
| [Create User with Argon2 Password](https://appwrite.io/docs/references/1.6.x/server-rest/users#createArgon2User) | ❌ | ✅ |
| [Create User with Bcrypt Password](https://appwrite.io/docs/references/1.6.x/server-rest/users#createBcryptUser) | ❌ | ✅ |
| [List Identities](https://appwrite.io/docs/references/1.6.x/server-rest/users#listIdentities) | ❌ | ✅ |
| [Delete Identity](https://appwrite.io/docs/references/1.6.x/server-rest/users#deleteIdentity) | ❌ | ✅ |
| [Create User with MD5 Password](https://appwrite.io/docs/references/1.6.x/server-rest/users#createMD5User) | ❌ | ✅ |
| [Create User with PHPass Password](https://appwrite.io/docs/references/1.6.x/server-rest/users#createPHPassUser) | ❌ | ✅ |
| [Create User with Scrypt Password](https://appwrite.io/docs/references/1.6.x/server-rest/users#createScryptUser) | ❌ | ✅ |
| [Create User with Scrypt Modified Password](https://appwrite.io/docs/references/1.6.x/server-rest/users#createScryptModifiedUser) | ❌ | ✅ |
| [Create User with SHA Password](https://appwrite.io/docs/references/1.6.x/server-rest/users#createSHAUser) | ❌ | ✅ |
| [Get User](https://appwrite.io/docs/references/1.6.x/server-rest/users#get) | ❌ | ✅ |
| [Delete User](https://appwrite.io/docs/references/1.6.x/server-rest/users#delete) | ❌ | ✅ |
| [Update Email](https://appwrite.io/docs/references/1.6.x/server-rest/users#updateEmail) | ❌ | ✅ |
| [Create User JWT](https://appwrite.io/docs/references/1.6.x/server-rest/users#createJWT) | ❌ | ✅ |
| [Update User Labels](https://appwrite.io/docs/references/1.6.x/server-rest/users#updateLabels) | ❌ | ✅ |
| [List User Logs](https://appwrite.io/docs/references/1.6.x/server-rest/users#listLogs) | ❌ | ✅ |
| [List User Memberships](https://appwrite.io/docs/references/1.6.x/server-rest/users#listMemberships) | ❌ | ✅ |
| [Update MFA](https://appwrite.io/docs/references/1.6.x/server-rest/users#updateMfa) | ❌ | ⬛ |
| [Delete Authenticator](https://appwrite.io/docs/references/1.6.x/server-rest/users#deleteMfaAuthenticator) | ❌ | ⬛ |
| [List Factors](https://appwrite.io/docs/references/1.6.x/server-rest/users#listMfaFactors) | ❌ | ⬛ |
| [Get MFA Recovery Codes](https://appwrite.io/docs/references/1.6.x/server-rest/users#getMfaRecoveryCodes) | ❌ | ⬛ |
| [Regenerate MFA Recovery Codes](https://appwrite.io/docs/references/1.6.x/server-rest/users#updateMfaRecoveryCodes) | ❌ | ⬛ |
| [Create MFA Recovery Codes](https://appwrite.io/docs/references/1.6.x/server-rest/users#createMfaRecoveryCodes) | ❌ | ⬛ |
| [Update Name](https://appwrite.io/docs/references/1.6.x/server-rest/users#updateName) | ❌ | ⬛ |
| [Update Password](https://appwrite.io/docs/references/1.6.x/server-rest/users#updatePassword) | ❌ | ⬛ |
| [Update Phone](https://appwrite.io/docs/references/1.6.x/server-rest/users#updatePhone) | ❌ | ⬛ |
| [Get User Preferences](https://appwrite.io/docs/references/1.6.x/server-rest/users#getPrefs) | ❌ | ⬛ |
| [Update User Preferences](https://appwrite.io/docs/references/1.6.x/server-rest/users#updatePrefs) | ❌ | ⬛ |
| [List User Sessions](https://appwrite.io/docs/references/1.6.x/server-rest/users#listSessions) | ❌ | ⬛ |
| [Create Session](https://appwrite.io/docs/references/1.6.x/server-rest/users#createSession) | ❌ | ⬛ |
| [Delete User Sessions](https://appwrite.io/docs/references/1.6.x/server-rest/users#deleteSessions) | ❌ | ⬛ |
| [Delete User Session](https://appwrite.io/docs/references/1.6.x/server-rest/users#deleteSession) | ❌ | ⬛ |
| [Update User Status](https://appwrite.io/docs/references/1.6.x/server-rest/users#updateStatus) | ❌ | ⬛ |
| [List User Targets](https://appwrite.io/docs/references/1.6.x/server-rest/users#listTargets) | ❌ | ⬛ |
| [Create User Target](https://appwrite.io/docs/references/1.6.x/server-rest/users#createTarget) | ❌ | ⬛ |
| [Get User Target](https://appwrite.io/docs/references/1.6.x/server-rest/users#getTarget) | ❌ | ⬛ |
| [Update User Target](https://appwrite.io/docs/references/1.6.x/server-rest/users#updateTarget) | ❌ | ⬛ |
| [Delete User Target](https://appwrite.io/docs/references/1.6.x/server-rest/users#deleteTarget) | ❌ | ⬛ |
| [Create Token](https://appwrite.io/docs/references/1.6.x/server-rest/users#createToken) | ❌ | ⬛ |
| [Update Email Verification](https://appwrite.io/docs/references/1.6.x/server-rest/users#updateEmailVerification) | ❌ | ⬛ |
| [Update Phone Verification](https://appwrite.io/docs/references/1.6.x/server-rest/users#updatePhoneVerification) | ❌ | ⬛ |

### Teams
<!-- ![0 / 26](https://progress-bar.dev/0/?scale=26&suffix=%20/%2026&width=120) -->
![Teams - 0 / 26](https://img.shields.io/badge/Teams-0%20%2F%2026-red?style=for-the-badge)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Teams](https://appwrite.io/docs/references/1.6.x/client-rest/teams#list) | ⬛ | ⬛ |
| [Create Team](https://appwrite.io/docs/references/1.6.x/client-rest/teams#create) | ⬛ | ⬛ |
| [Get Team](https://appwrite.io/docs/references/1.6.x/client-rest/teams#get) | ⬛ | ⬛ |
| [Updatet Name](https://appwrite.io/docs/references/1.6.x/client-rest/teams#updateName) | ⬛ | ⬛ |
| [Delete Team](https://appwrite.io/docs/references/1.6.x/client-rest/teams#delete) | ⬛ | ⬛ |
| [List Team Memberships](https://appwrite.io/docs/references/1.6.x/client-rest/teams#listMemberships) | ⬛ | ⬛ |
| [Create Team Membership](https://appwrite.io/docs/references/1.6.x/client-rest/teams#createMembership) | ⬛ | ⬛ |
| [Get Team Membership](https://appwrite.io/docs/references/1.6.x/client-rest/teams#getMembership) | ⬛ | ⬛ |
| [Update Membership](https://appwrite.io/docs/references/1.6.x/client-rest/teams#updateMembership) | ⬛ | ⬛ |
| [Delete Team Membership](https://appwrite.io/docs/references/1.6.x/client-rest/teams#deleteMembership) | ⬛ | ⬛ |
| [Update Team Membership Status](https://appwrite.io/docs/references/1.6.x/client-rest/teams#updateMembershipStatus) | ⬛ | ⬛ |
| [Get Team Memberships](https://appwrite.io/docs/references/1.6.x/client-rest/teams#getPrefs) | ⬛ | ⬛ |
| [Update Preferences](https://appwrite.io/docs/references/1.6.x/client-rest/teams#updatePrefs) | ⬛ | ⬛ |

### Databases
<!-- ![0 / 47](https://progress-bar.dev/0/?scale=47&suffix=%20/%2047&width=120) -->
![Databases - 0 / 47](https://img.shields.io/badge/Databases-0%20%2F%2047-red?style=for-the-badge)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Databases](https://appwrite.io/docs/references/1.6.x/server-rest/databases#list) | ❌ | ⬛ |
| [Create Databases](https://appwrite.io/docs/references/1.6.x/server-rest/databases#create) | ❌ | ⬛ |
| [Get Database](https://appwrite.io/docs/references/1.6.x/server-rest/databases#get) | ❌ | ⬛ |
| [Update Database](https://appwrite.io/docs/references/1.6.x/server-rest/databases#update) | ❌ | ⬛ |
| [Delete Database](https://appwrite.io/docs/references/1.6.x/server-rest/databases#delete) | ❌ | ⬛ |
| [List Collections](https://appwrite.io/docs/references/1.6.x/server-rest/databases#listCollections) | ❌ | ⬛ |
| [Create Collection](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createCollection) | ❌ | ⬛ |
| [Get Collections](https://appwrite.io/docs/references/1.6.x/server-rest/databases#getCollection) | ❌ | ⬛ |
| [Update Collection](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateCollection) | ❌ | ⬛ |
| [Delete Collection](https://appwrite.io/docs/references/1.6.x/server-rest/databases#deleteCollection) | ❌ | ⬛ |
| [List Attributes](https://appwrite.io/docs/references/1.6.x/server-rest/databases#listAttributes) | ❌ | ⬛ |
| [Create Boolean Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createBooleanAttribute) | ❌ | ⬛ |
| [Update Boolean Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateBooleanAttribute) | ❌ | ⬛ |
| [Create Datatime Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createDatetimeAttribute) | ❌ | ⬛ |
| [Update Datetime Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateDatetimeAttribute) | ❌ | ⬛ |
| [Create Email Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createEmailAttribute) | ❌ | ⬛ |
| [Update Email Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateEmailAttribute) | ❌ | ⬛ |
| [Create Enum Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createEnumAttribute) | ❌ | ⬛ |
| [Update Enum Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateEnumAttribute) | ❌ | ⬛ |
| [Create Float Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createFloatAttribute) | ❌ | ⬛ |
| [Update Float Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateFloatAttribute) | ❌ | ⬛ |
| [Create Integer Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createIntegerAttribute) | ❌ | ⬛ |
| [Update Integer attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateIntegerAttribute) | ❌ | ⬛ |
| [Create IP Address Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createIpAttribute) | ❌ | ⬛ |
| [Update IP Address Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateIpAttribute) | ❌ | ⬛ |
| [Create Relationship Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createRelationshipAttribute) | ❌ | ⬛ |
| [Create String Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createStringAttribute) | ❌ | ⬛ |
| [Update String Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateStringAttribute) | ❌ | ⬛ |
| [Create URL Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createUrlAttribute) | ❌ | ⬛ |
| [Update URL Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateUrlAttribute) | ❌ | ⬛ |
| [Get Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#getAttribute) | ❌ | ⬛ |
| [Delete Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#deleteAttribute) | ❌ | ⬛ |
| [Update Relationship Attribute](https://appwrite.io/docs/references/1.6.x/server-rest/databases#updateRelationshipAttribute) | ❌ | ⬛ |
| [List Documents](https://appwrite.io/docs/references/1.6.x/client-rest/databases#listDocuments) | ⬛ | ⬛ |
| [Create Document](https://appwrite.io/docs/references/1.6.x/client-rest/databases#createDocument) | ⬛ | ⬛ |
| [Get Document](https://appwrite.io/docs/references/1.6.x/client-rest/databases#getDocument) | ⬛ | ⬛ |
| [Update Document](https://appwrite.io/docs/references/1.6.x/client-rest/databases#updateDocument) | ⬛ | ⬛ |
| [Delete Document](https://appwrite.io/docs/references/1.6.x/client-rest/databases#deleteDocument) | ⬛ | ⬛ |
| [List Indexes](https://appwrite.io/docs/references/1.6.x/server-rest/databases#listIndexes) | ❌ | ⬛ |
| [Create Index](https://appwrite.io/docs/references/1.6.x/server-rest/databases#createIndex) | ❌ | ⬛ |
| [Get Index](https://appwrite.io/docs/references/1.6.x/server-rest/databases#getIndex) | ❌ | ⬛ |
| [Delete Index](https://appwrite.io/docs/references/1.6.x/server-rest/databases#deleteIndex) | ❌ | ⬛ |

### Storage
<!-- ![0 / 21](https://progress-bar.dev/0/?scale=21&suffix=%20/%2021&width=120) -->
![storage - 0 / 21](https://img.shields.io/badge/Storage-0%20%2F%2021-red?style=for-the-badge)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Buckets](https://appwrite.io/docs/references/1.6.x/server-rest/storage#listBuckets) | ❌ | ⬛ |
| [Create Bucket](https://appwrite.io/docs/references/1.6.x/server-rest/storage#createBucket) | ❌ | ⬛ |
| [Get Bucket](https://appwrite.io/docs/references/1.6.x/server-rest/storage#getBucket) | ❌ | ⬛ |
| [Update Bucket](https://appwrite.io/docs/references/1.6.x/server-rest/storage#updateBucket) | ❌ | ⬛ |
| [Delete Bucket](https://appwrite.io/docs/references/1.6.x/server-rest/storage#deleteBucket) | ❌ | ⬛ |
| [List Files](https://appwrite.io/docs/references/1.6.x/client-rest/storage#listFiles) | ⬛ | ⬛ |
| [Create File](https://appwrite.io/docs/references/1.6.x/client-rest/storage#createFile) | ⬛ | ⬛ |
| [Get File](https://appwrite.io/docs/references/1.6.x/client-rest/storage#getFile) | ⬛ | ⬛ |
| [Update File](https://appwrite.io/docs/references/1.6.x/client-rest/storage#updateFile) | ⬛ | ⬛ |
| [Delete File](https://appwrite.io/docs/references/1.6.x/client-rest/storage#deleteFile) | ⬛ | ⬛ |
| [Get File For Download](https://appwrite.io/docs/references/1.6.x/client-rest/storage#getFileDownload) | ⬛ | ⬛ |
| [Get File Preview](https://appwrite.io/docs/references/1.6.x/client-rest/storage#getFilePreview) | ⬛ | ⬛ |
| [Get File For View](https://appwrite.io/docs/references/1.6.x/client-rest/storage#getFileView) | ⬛ | ⬛ |

### Functions
<!-- ![0 / 24](https://progress-bar.dev/0/?scale=24&suffix=%20/%2024&width=120) -->
![Functions - 0 / 24](https://img.shields.io/badge/Functions-0%20%2F%2024-red?style=for-the-badge)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Functions](https://appwrite.io/docs/references/1.6.x/server-rest/functions#list) | ❌ | ⬛ |
| [Create Function](https://appwrite.io/docs/references/1.6.x/server-rest/functions#create) | ❌ | ⬛ |
| [List Runtimes](https://appwrite.io/docs/references/1.6.x/server-rest/functions#listRuntimes) | ❌ | ⬛ |
| [Get Function](https://appwrite.io/docs/references/1.6.x/server-rest/functions#get) | ❌ | ⬛ |
| [Update Function](https://appwrite.io/docs/references/1.6.x/server-rest/functions#update) | ❌ | ⬛ |
| [Delete Function](https://appwrite.io/docs/references/1.6.x/server-rest/functions#delete) | ❌ | ⬛ |
| [List Deployments](https://appwrite.io/docs/references/1.6.x/server-rest/functions#listDeployments) | ❌ | ⬛ |
| [Create Deployment](https://appwrite.io/docs/references/1.6.x/server-rest/functions#createDeployment) | ❌ | ⬛ |
| [Get Deployment](https://appwrite.io/docs/references/1.6.x/server-rest/functions#getDeployment) | ❌ | ⬛ |
| [Update Function Deployment](https://appwrite.io/docs/references/1.6.x/server-rest/functions#updateDeployment) | ❌ | ⬛ |
| [Delete Deployment](https://appwrite.io/docs/references/1.6.x/server-rest/functions#deleteDeployment) | ❌ | ⬛ |
| [Create Build](https://appwrite.io/docs/references/1.6.x/server-rest/functions#createBuild) | ❌ | ⬛ |
| [Download Deployment](https://appwrite.io/docs/references/1.6.x/server-rest/functions#downloadDeployment) | ❌ | ⬛ |
| [List Executions](https://appwrite.io/docs/references/1.6.x/client-rest/functions#listExecutions) | ⬛ | ⬛ |
| [Create Execution](https://appwrite.io/docs/references/1.6.x/client-rest/functions#createExecution) | ⬛ | ⬛ |
| [Get Execution](https://appwrite.io/docs/references/1.6.x/client-rest/functions#getExecution) | ⬛ | ⬛ |
| [List Variables](https://appwrite.io/docs/references/1.6.x/server-rest/functions#listVariables) | ❌ | ⬛ |
| [Create Variable](https://appwrite.io/docs/references/1.6.x/server-rest/functions#createVariable) | ❌ | ⬛ |
| [Get Variable](https://appwrite.io/docs/references/1.6.x/server-rest/functions#getVariable) | ❌ | ⬛ |
| [Update Variable](https://appwrite.io/docs/references/1.6.x/server-rest/functions#updateVariable) | ❌ | ⬛ |
| [Delete Variable](https://appwrite.io/docs/references/1.6.x/server-rest/functions#deleteVariable) | ❌ | ⬛ |

### Messaging
<!-- ![0 / 48](https://progress-bar.dev/0/?scale=48&suffix=%20/%2048&width=120) -->
![Messaging - 0 / 48](https://img.shields.io/badge/Messaging-0%20%2F%2048-red?style=for-the-badge)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Messages](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#listMessages) | ❌ | ⬛ |
| [Create Email](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createEmail) | ❌ | ⬛ |
| [Update Email](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateEmail) | ❌ | ⬛ |
| [Create Push Notification](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createPush) | ❌ | ⬛ |
| [Update Push Notification](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updatePush) | ❌ | ⬛ |
| [Create SMS](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createSms) | ❌ | ⬛ |
| [Update SMS](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateSms) | ❌ | ⬛ |
| [Get Message](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#getMessage) | ❌ | ⬛ |
| [Delete Message](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#delete) | ❌ | ⬛ |
| [List Message Logs](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#listMessageLogs) | ❌ | ⬛ |
| [List Message Targets](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#listTargets) | ❌ | ⬛ |
| [List Providers](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#listProviders) | ❌ | ⬛ |
| [Create APNS Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createApnsProvider) | ❌ | ⬛ |
| [Update APNS Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateApnsProvider) | ❌ | ⬛ |
| [Create FCM Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createFcmProvider) | ❌ | ⬛ |
| [Update FCM Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateFcmProvider) | ❌ | ⬛ |
| [Create Mailgun Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createMailgunProvider) | ❌ | ⬛ |
| [Update Mailgun Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateMailgunProvider) | ❌ | ⬛ |
| [Create Msg91 Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createMsg91Provider) | ❌ | ⬛ |
| [Update Msg91 Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateMsg91Provider) | ❌ | ⬛ |
| [Create Sendgrid Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createSendgridProvider) | ❌ | ⬛ |
| [Update Sendgrid Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateSendgridProvider) | ❌ | ⬛ |
| [Create SMTP Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createSmtpProvider) | ❌ | ⬛ |
| [Update SMTP Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateSmtpProvider) | ❌ | ⬛ |
| [Create Telesign Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createTelesignProvider) | ❌ | ⬛ |
| [Update Telesign Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateTelesignProvider) | ❌ | ⬛ |
| [Create Textmagic Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createTextmagicProvider) | ❌ | ⬛ |
| [Update Textmagic Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateTextmagicProvider) | ❌ | ⬛ |
| [Create Twilio Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createTwilioProvider) | ❌ | ⬛ |
| [Update Twilio Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateTwilioProvider) | ❌ | ⬛ |
| [Create Vonage Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createVonageProvider) | ❌ | ⬛ |
| [Update Vonage Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateVonageProvider) | ❌ | ⬛ |
| [Get Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#getProvider) | ❌ | ⬛ |
| [Delete Provider](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#deleteProvider) | ❌ | ⬛ |
| [List Provider Logs](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#listProviderLogs) | ❌ | ⬛ |
| [List Subscriber Logs](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#listSubscriberLogs) | ❌ | ⬛ |
| [List Topics](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#listTopics) | ❌ | ⬛ |
| [Create Topic](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#createTopic) | ❌ | ⬛ |
| [Get Topic](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#getTopic) | ❌ | ⬛ |
| [Update Topic](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#updateTopic) | ❌ | ⬛ |
| [Delete Topic](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#deleteTopic) | ❌ | ⬛ |
| [List Topic Logs](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#listTopicLogs) | ❌ | ⬛ |
| [List Subscribers](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#listSubscribers) | ❌ | ⬛ |
| [Create Subscriber](https://appwrite.io/docs/references/1.6.x/client-rest/messaging#createSubscriber) | ⬛ | ⬛ |
| [Get Subscriber](https://appwrite.io/docs/references/1.6.x/server-rest/messaging#getSubscriber) | ❌ | ⬛ |
| [Delete Subscriber](https://appwrite.io/docs/references/1.6.x/client-rest/messaging#deleteSubscriber) | ⬛ | ⬛ |

### Locale
<!-- ![0 / 15](https://progress-bar.dev/0/?scale=15&suffix=%20/%2015&width=120) -->
![Locale - 0 / 15](https://img.shields.io/badge/Locale-0%20%2F%2015-red?style=for-the-badge)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [Get User Locale](https://appwrite.io/docs/references/1.6.x/client-rest/locale#get) | ⬛ | ❌ |
| [List Locale Codes](https://appwrite.io/docs/references/1.6.x/client-rest/locale#listCodes) | ⬛ | ⬛ |
| [List Continents](https://appwrite.io/docs/references/1.6.x/client-rest/locale#listContinents) | ⬛ | ⬛ |
| [List Countries](https://appwrite.io/docs/references/1.6.x/client-rest/locale#listCountries) | ⬛ | ⬛ |
| [List EU Countries](https://appwrite.io/docs/references/1.6.x/client-rest/locale#listCountriesEU) | ⬛ | ⬛ |
| [List Countries Phone Codes](https://appwrite.io/docs/references/1.6.x/client-rest/locale#listCountriesPhones) | ⬛ | ⬛ |
| [List Currencies](https://appwrite.io/docs/references/1.6.x/client-rest/locale#listCurrencies) | ⬛ | ⬛ |
| [List Languages](https://appwrite.io/docs/references/1.6.x/client-rest/locale#listLanguages) | ⬛ | ⬛ |

### Avatars
<!-- ![0 / 14](https://progress-bar.dev/0/?scale=14&suffix=%20/%2014&width=120) -->
![Avatars - 0 / 14](https://img.shields.io/badge/Avatars-0%20%2F%2014-red?style=for-the-badge)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [Get Browser Icon](https://appwrite.io/docs/references/1.6.x/client-rest/avatars#getBrowser) | ⬛ | ⬛ |
| [Get Credit Card Icon](https://appwrite.io/docs/references/1.6.x/client-rest/avatars#getCreditCard) | ⬛ | ⬛ |
| [Get Favicon](https://appwrite.io/docs/references/1.6.x/client-rest/avatars#getFavicon) | ⬛ | ⬛ |
| [Get Country Flag](https://appwrite.io/docs/references/1.6.x/client-rest/avatars#getFlag) | ⬛ | ⬛ |
| [Get Image From Url](https://appwrite.io/docs/references/1.6.x/client-rest/avatars#getImage) | ⬛ | ⬛ |
| [Get Initials](https://appwrite.io/docs/references/1.6.x/client-rest/avatars#getInitials) | ⬛ | ⬛ |
| [Get QR Code](https://appwrite.io/docs/references/1.6.x/client-rest/avatars#getQR) | ⬛ | ⬛ |
