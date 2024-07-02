# AppwriteClient

## Work in Progress
This is a work in progress. There are 2 SDK's - one for client and another for server. You might desire client functionality on the server, particulary is making use of server side rendering, so on the server it might make most sense to use both client and server SDKs. Each have different functionality available.

## Progress
### Server & Client
![2 / 298](https://progress-bar.dev/2/?scale=298&suffix=%20/%20298&width=500)
### Server Only
![1 / 195](https://progress-bar.dev/1/?scale=195&suffix=%20/%20195&width=300)
### Client Only
![1 / 93](https://progress-bar.dev/1/?scale=93&suffix=%20/%2093&width=300)

## Key
| Icon | Definition |
|:-:|:-:|
| ✅ | The endpoint is implemented for the given SDK type (client or server) |
| ⬛ | The endpoint is not yet implemented for the given SDK type (client or server), but will be |
| ❌ | There is currently no intention to implement the endpoint for the given SDK type (client or server) |

## Account
![2 / 52](https://progress-bar.dev/2/?scale=52&suffix=%20/%2052&width=120)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [Get Account](https://appwrite.io/docs/references/1.5.x/client-rest/account#get) | ✅ | ❌ |
| [Create Account](https://appwrite.io/docs/references/1.5.x/client-rest/account#create) | ⬛ | ✅ |
| [Update Email](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateEmail) | ⬛ | ❌ |
| [List Identities](https://appwrite.io/docs/references/1.5.x/client-rest/account#listIdentities) | ⬛ | ❌ |
| [Delete Identity](https://appwrite.io/docs/references/1.5.x/client-rest/account#deleteIdentity) | ⬛ | ❌ |
| [Create JWT](https://appwrite.io/docs/references/1.5.x/client-rest/account#createJWT) | ⬛ | ❌ |
| [List Logs](https://appwrite.io/docs/references/1.5.x/client-rest/account#listLogs) | ⬛ | ❌ |
| [Update MFA](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateMFA) | ⬛ | ❌ |
| [Add Authenticator](https://appwrite.io/docs/references/1.5.x/client-rest/account#createMfaAuthenticator) | ⬛ | ❌ |
| [Verify Authenticator](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateMfaAuthenticator) | ⬛ | ❌ |
| [Delete Authenticator](https://appwrite.io/docs/references/1.5.x/client-rest/account#deleteMfaAuthenticator) | ⬛ | ❌ |
| [Create 2FA Challenge](https://appwrite.io/docs/references/1.5.x/client-rest/account#createMfaChallenge) | ⬛ | ❌ |
| [Create MFA Challenge (confirmation)](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateMfaChallenge) | ⬛ | ❌ |
| [List Factors](https://appwrite.io/docs/references/1.5.x/client-rest/account#listMfaFactors) | ⬛ | ❌ |
| [Get MFA Recovery Codes](https://appwrite.io/docs/references/1.5.x/client-rest/account#getMfaRecoveryCodes) | ⬛ | ❌ |
| [Create MFA Recovery Codes](https://appwrite.io/docs/references/1.5.x/client-rest/account#createMfaRecoveryCodes) | ⬛ | ❌ |
| [Regenerate MFA Recovery Codes](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateMfaRecoveryCodes) | ⬛ | ❌ |
| [Update Name](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateName) | ⬛ | ❌ |
| [Update Password](https://appwrite.io/docs/references/1.5.x/client-rest/account#updatePassword) | ⬛ | ❌ |
| [Update Phone](https://appwrite.io/docs/references/1.5.x/client-rest/account#updatePhone) | ⬛ | ❌ |
| [Get Account Preferences](https://appwrite.io/docs/references/1.5.x/client-rest/account#getPrefs) | ⬛ | ❌ |
| [Update Preferences](https://appwrite.io/docs/references/1.5.x/client-rest/account#updatePrefs) | ⬛ | ❌ |
| [Create Password Recovery](https://appwrite.io/docs/references/1.5.x/client-rest/account#createRecovery) | ⬛ | ❌ |
| [Create Password Recovery (Confirmation)](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateRecovery) | ⬛ | ❌ |
| [List Sessions](https://appwrite.io/docs/references/1.5.x/client-rest/account#listSessions) | ⬛ | ❌ |
| [Delete Sessions](https://appwrite.io/docs/references/1.5.x/client-rest/account#deleteSessions) | ⬛ | ❌ |
| [Create Anonymous Session](https://appwrite.io/docs/references/1.5.x/client-rest/account#createAnonymousSession) | ⬛ | ❌ |
| [Create Email Password Session](https://appwrite.io/docs/references/1.5.x/client-rest/account#createEmailPasswordSession) | ⬛ | ❌ |
| [Update Magic URL Session](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateMagicURLSession) | ⬛ | ❌ |
| [Create OAuth2 Session](https://appwrite.io/docs/references/1.5.x/client-rest/account#createOAuth2Session) | ⬛ | ❌ |
| [Update Phone Session](https://appwrite.io/docs/references/1.5.x/client-rest/account#updatePhoneSession) | ⬛ | ❌ |
| [Create Session](https://appwrite.io/docs/references/1.5.x/client-rest/account#createSession) | ⬛ | ❌ |
| [Get Session](https://appwrite.io/docs/references/1.5.x/client-rest/account#getSession) | ⬛ | ❌ |
| [Update Session](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateSession) | ⬛ | ❌ |
| [Delete Session](https://appwrite.io/docs/references/1.5.x/client-rest/account#deleteSession) | ⬛ | ❌ |
| [Update Status](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateStatus) | ⬛ | ❌ |
| [Create Push Target](https://appwrite.io/docs/references/1.5.x/client-rest/account#createPushTarget) | ⬛ | ❌ |
| [Update Push Target](https://appwrite.io/docs/references/1.5.x/client-rest/account#updatePushTarget) | ⬛ | ❌ |
| [Delete Push Target](https://appwrite.io/docs/references/1.5.x/client-rest/account#deletePushTarget) | ⬛ | ❌ |
| [Create Email Token (OTP)](https://appwrite.io/docs/references/1.5.x/client-rest/account#createEmailToken) | ⬛ | ⬛ |
| [Create Magic URL Token](https://appwrite.io/docs/references/1.5.x/client-rest/account#createMagicURLToken) | ⬛ | ⬛ |
| [Create OAuth2 Token](https://appwrite.io/docs/references/1.5.x/client-rest/account#createOAuth2Token) | ⬛ | ⬛ |
| [Create Phone Token](https://appwrite.io/docs/references/1.5.x/client-rest/account#createPhoneToken) | ⬛ | ⬛ |
| [Create Email Verification](https://appwrite.io/docs/references/1.5.x/client-rest/account#createVerification) | ⬛ | ❌ |
| [Create Email Verification (Confirmation)](https://appwrite.io/docs/references/1.5.x/client-rest/account#updateVerification) | ⬛ | ❌ |
| [Create Phone Verification](https://appwrite.io/docs/references/1.5.x/client-rest/account#createPhoneVerification) | ⬛ | ❌ |
| [Create Phone Verification (Confirmation)](https://appwrite.io/docs/references/1.5.x/client-rest/account#updatePhoneVerification) | ⬛ | ❌ |

## Users
![0 / 41](https://progress-bar.dev/0/?scale=41&suffix=%20/%2041&width=120)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Users](https://appwrite.io/docs/references/1.5.x/server-rest/users#list) | ❌ | ⬛ |
| [Create User](https://appwrite.io/docs/references/1.5.x/server-rest/users#create) | ❌ | ⬛ |
| [Create User with Argon2 Password](https://appwrite.io/docs/references/1.5.x/server-rest/users#createArgon2User) | ❌ | ⬛ |
| [Create User with Bcrypt Password](https://appwrite.io/docs/references/1.5.x/server-rest/users#createBcryptUser) | ❌ | ⬛ |
| [List Identities](https://appwrite.io/docs/references/1.5.x/server-rest/users#listIdentities) | ❌ | ⬛ |
| [Delete Identity](https://appwrite.io/docs/references/1.5.x/server-rest/users#deleteIdentity) | ❌ | ⬛ |
| [Create User with MD5 Password](https://appwrite.io/docs/references/1.5.x/server-rest/users#createMD5User) | ❌ | ⬛ |
| [Create User with PHPass Password](https://appwrite.io/docs/references/1.5.x/server-rest/users#createPHPassUser) | ❌ | ⬛ |
| [Create User with Scrypt Password](https://appwrite.io/docs/references/1.5.x/server-rest/users#createScryptUser) | ❌ | ⬛ |
| [Create User with Scrypt Modified Password](https://appwrite.io/docs/references/1.5.x/server-rest/users#createScryptModifiedUser) | ❌ | ⬛ |
| [Create User with SHA Password](https://appwrite.io/docs/references/1.5.x/server-rest/users#createSHAUser) | ❌ | ⬛ |
| [Get User](https://appwrite.io/docs/references/1.5.x/server-rest/users#get) | ❌ | ⬛ |
| [Delete User](https://appwrite.io/docs/references/1.5.x/server-rest/users#delete) | ❌ | ⬛ |
| [Update Email](https://appwrite.io/docs/references/1.5.x/server-rest/users#updateEmail) | ❌ | ⬛ |
| [Update User Labels](https://appwrite.io/docs/references/1.5.x/server-rest/users#updateLabels) | ❌ | ⬛ |
| [List User Logs](https://appwrite.io/docs/references/1.5.x/server-rest/users#listLogs) | ❌ | ⬛ |
| [List User Memberships](https://appwrite.io/docs/references/1.5.x/server-rest/users#listMemberships) | ❌ | ⬛ |
| [Update MFA](https://appwrite.io/docs/references/1.5.x/server-rest/users#updateMfa) | ❌ | ⬛ |
| [Delete Authenticator](https://appwrite.io/docs/references/1.5.x/server-rest/users#deleteMfaAuthenticator) | ❌ | ⬛ |
| [List Factors](https://appwrite.io/docs/references/1.5.x/server-rest/users#listMfaFactors) | ❌ | ⬛ |
| [Get MFA Recovery Codes](https://appwrite.io/docs/references/1.5.x/server-rest/users#getMfaRecoveryCodes) | ❌ | ⬛ |
| [Regenerator MFA Recovery Codes](https://appwrite.io/docs/references/1.5.x/server-rest/users#updateMfaRecoveryCodes) | ❌ | ⬛ |
| [Create MFA Recovery Codes](https://appwrite.io/docs/references/1.5.x/server-rest/users#createMfaRecoveryCodes) | ❌ | ⬛ |
| [Update Name](https://appwrite.io/docs/references/1.5.x/server-rest/users#updateName) | ❌ | ⬛ |
| [Update Password](https://appwrite.io/docs/references/1.5.x/server-rest/users#updatePassword) | ❌ | ⬛ |
| [Update Phone](https://appwrite.io/docs/references/1.5.x/server-rest/users#updatePhone) | ❌ | ⬛ |
| [Get User Preferences](https://appwrite.io/docs/references/1.5.x/server-rest/users#getPrefs) | ❌ | ⬛ |
| [Update User Preferences](https://appwrite.io/docs/references/1.5.x/server-rest/users#updatePrefs) | ❌ | ⬛ |
| [List User Sessions](https://appwrite.io/docs/references/1.5.x/server-rest/users#listSessions) | ❌ | ⬛ |
| [Create Session](https://appwrite.io/docs/references/1.5.x/server-rest/users#createSession) | ❌ | ⬛ |
| [Delete User Sessions](https://appwrite.io/docs/references/1.5.x/server-rest/users#deleteSessions) | ❌ | ⬛ |
| [Delete User Session](https://appwrite.io/docs/references/1.5.x/server-rest/users#deleteSession) | ❌ | ⬛ |
| [Update User Status](https://appwrite.io/docs/references/1.5.x/server-rest/users#updateStatus) | ❌ | ⬛ |
| [List User Targets](https://appwrite.io/docs/references/1.5.x/server-rest/users#listTargets) | ❌ | ⬛ |
| [Create User Target](https://appwrite.io/docs/references/1.5.x/server-rest/users#createTarget) | ❌ | ⬛ |
| [Get User Target](https://appwrite.io/docs/references/1.5.x/server-rest/users#getTarget) | ❌ | ⬛ |
| [Update User Target](https://appwrite.io/docs/references/1.5.x/server-rest/users#updateTarget) | ❌ | ⬛ |
| [Delete User Target](https://appwrite.io/docs/references/1.5.x/server-rest/users#deleteTarget) | ❌ | ⬛ |
| [Create Token](https://appwrite.io/docs/references/1.5.x/server-rest/users#createToken) | ❌ | ⬛ |
| [Update Email Verification](https://appwrite.io/docs/references/1.5.x/server-rest/users#updateEmailVerification) | ❌ | ⬛ |
| [Update Phone Verification](https://appwrite.io/docs/references/1.5.x/server-rest/users#updatePhoneVerification) | ❌ | ⬛ |

## Teams
![0 / 26](https://progress-bar.dev/0/?scale=26&suffix=%20/%2026&width=120)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Teams](https://appwrite.io/docs/references/1.5.x/client-rest/teams#list) | ⬛ | ⬛ |
| [Create Team](https://appwrite.io/docs/references/1.5.x/client-rest/teams#create) | ⬛ | ⬛ |
| [Get Team](https://appwrite.io/docs/references/1.5.x/client-rest/teams#get) | ⬛ | ⬛ |
| [Updatet Name](https://appwrite.io/docs/references/1.5.x/client-rest/teams#updateName) | ⬛ | ⬛ |
| [Delete Team](https://appwrite.io/docs/references/1.5.x/client-rest/teams#delete) | ⬛ | ⬛ |
| [List Team Memberships](https://appwrite.io/docs/references/1.5.x/client-rest/teams#listMemberships) | ⬛ | ⬛ |
| [Create Team Membership](https://appwrite.io/docs/references/1.5.x/client-rest/teams#createMembership) | ⬛ | ⬛ |
| [Get Team Membership](https://appwrite.io/docs/references/1.5.x/client-rest/teams#getMembership) | ⬛ | ⬛ |
| [Update Membership](https://appwrite.io/docs/references/1.5.x/client-rest/teams#updateMembership) | ⬛ | ⬛ |
| [Delete Team Membership](https://appwrite.io/docs/references/1.5.x/client-rest/teams#deleteMembership) | ⬛ | ⬛ |
| [Update Team Membership Status](https://appwrite.io/docs/references/1.5.x/client-rest/teams#updateMembershipStatus) | ⬛ | ⬛ |
| [Get Team Memberships](https://appwrite.io/docs/references/1.5.x/client-rest/teams#getPrefs) | ⬛ | ⬛ |
| [Update Preferences](https://appwrite.io/docs/references/1.5.x/client-rest/teams#updatePrefs) | ⬛ | ⬛ |

## Databases
![0 / 47](https://progress-bar.dev/0/?scale=47&suffix=%20/%2047&width=120)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Databases](https://appwrite.io/docs/references/1.5.x/server-rest/databases#list) | ❌ | ⬛ |
| [Create Databases](https://appwrite.io/docs/references/1.5.x/server-rest/databases#create) | ❌ | ⬛ |
| [Get Database](https://appwrite.io/docs/references/1.5.x/server-rest/databases#get) | ❌ | ⬛ |
| [Update Database](https://appwrite.io/docs/references/1.5.x/server-rest/databases#update) | ❌ | ⬛ |
| [Delete Database](https://appwrite.io/docs/references/1.5.x/server-rest/databases#delete) | ❌ | ⬛ |
| [List Collections](https://appwrite.io/docs/references/1.5.x/server-rest/databases#listCollections) | ❌ | ⬛ |
| [Create Collection](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createCollection) | ❌ | ⬛ |
| [Get Collections](https://appwrite.io/docs/references/1.5.x/server-rest/databases#getCollection) | ❌ | ⬛ |
| [Update Collection](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateCollection) | ❌ | ⬛ |
| [Delete Collection](https://appwrite.io/docs/references/1.5.x/server-rest/databases#deleteCollection) | ❌ | ⬛ |
| [List Attributes](https://appwrite.io/docs/references/1.5.x/server-rest/databases#listAttributes) | ❌ | ⬛ |
| [Create Boolean Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createBooleanAttribute) | ❌ | ⬛ |
| [Update Boolean Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateBooleanAttribute) | ❌ | ⬛ |
| [Create Datatime Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createDatetimeAttribute) | ❌ | ⬛ |
| [Update Datetime Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateDatetimeAttribute) | ❌ | ⬛ |
| [Create Email Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createEmailAttribute) | ❌ | ⬛ |
| [Update Email Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateEmailAttribute) | ❌ | ⬛ |
| [Create Enum Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createEnumAttribute) | ❌ | ⬛ |
| [Update Enum Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateEnumAttribute) | ❌ | ⬛ |
| [Create Float Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createFloatAttribute) | ❌ | ⬛ |
| [Update Float Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateFloatAttribute) | ❌ | ⬛ |
| [Create Integer Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createIntegerAttribute) | ❌ | ⬛ |
| [Update Integer attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateIntegerAttribute) | ❌ | ⬛ |
| [Create IP Address Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createIpAttribute) | ❌ | ⬛ |
| [Update IP Address Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateIpAttribute) | ❌ | ⬛ |
| [Create Relationship Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createRelationshipAttribute) | ❌ | ⬛ |
| [Create String Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createStringAttribute) | ❌ | ⬛ |
| [Update String Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateStringAttribute) | ❌ | ⬛ |
| [Create URL Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createUrlAttribute) | ❌ | ⬛ |
| [Update URL Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateUrlAttribute) | ❌ | ⬛ |
| [Get Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#getAttribute) | ❌ | ⬛ |
| [Delete Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#deleteAttribute) | ❌ | ⬛ |
| [Update Relationship Attribute](https://appwrite.io/docs/references/1.5.x/server-rest/databases#updateRelationshipAttribute) | ❌ | ⬛ |
| [List Documents](https://appwrite.io/docs/references/1.5.x/client-rest/databases#listDocuments) | ⬛ | ⬛ |
| [Create Document](https://appwrite.io/docs/references/1.5.x/client-rest/databases#createDocument) | ⬛ | ⬛ |
| [Get Document](https://appwrite.io/docs/references/1.5.x/client-rest/databases#getDocument) | ⬛ | ⬛ |
| [Update Document](https://appwrite.io/docs/references/1.5.x/client-rest/databases#updateDocument) | ⬛ | ⬛ |
| [Delete Document](https://appwrite.io/docs/references/1.5.x/client-rest/databases#deleteDocument) | ⬛ | ⬛ |
| [List Indexes](https://appwrite.io/docs/references/1.5.x/server-rest/databases#listIndexes) | ❌ | ⬛ |
| [Create Index](https://appwrite.io/docs/references/1.5.x/server-rest/databases#createIndex) | ❌ | ⬛ |
| [Get Index](https://appwrite.io/docs/references/1.5.x/server-rest/databases#getIndex) | ❌ | ⬛ |
| [Delete Index](https://appwrite.io/docs/references/1.5.x/server-rest/databases#deleteIndex) | ❌ | ⬛ |

## Storage
![0 / 21](https://progress-bar.dev/0/?scale=21&suffix=%20/%2021&width=120)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Buckets](https://appwrite.io/docs/references/1.5.x/server-rest/storage#listBuckets) | ❌ | ⬛ |
| [Create Bucket](https://appwrite.io/docs/references/1.5.x/server-rest/storage#createBucket) | ❌ | ⬛ |
| [Get Bucket](https://appwrite.io/docs/references/1.5.x/server-rest/storage#getBucket) | ❌ | ⬛ |
| [Update Bucket](https://appwrite.io/docs/references/1.5.x/server-rest/storage#updateBucket) | ❌ | ⬛ |
| [Delete Bucket](https://appwrite.io/docs/references/1.5.x/server-rest/storage#deleteBucket) | ❌ | ⬛ |
| [List Files](https://appwrite.io/docs/references/1.5.x/client-rest/storage#listFiles) | ⬛ | ⬛ |
| [Create File](https://appwrite.io/docs/references/1.5.x/client-rest/storage#createFile) | ⬛ | ⬛ |
| [Get File](https://appwrite.io/docs/references/1.5.x/client-rest/storage#getFile) | ⬛ | ⬛ |
| [Update File](https://appwrite.io/docs/references/1.5.x/client-rest/storage#updateFile) | ⬛ | ⬛ |
| [Delete File](https://appwrite.io/docs/references/1.5.x/client-rest/storage#deleteFile) | ⬛ | ⬛ |
| [Get File For Download](https://appwrite.io/docs/references/1.5.x/client-rest/storage#getFileDownload) | ⬛ | ⬛ |
| [Get File Preview](https://appwrite.io/docs/references/1.5.x/client-rest/storage#getFilePreview) | ⬛ | ⬛ |
| [Get File For View](https://appwrite.io/docs/references/1.5.x/client-rest/storage#getFileView) | ⬛ | ⬛ |

## Functions
![0 / 24](https://progress-bar.dev/0/?scale=24&suffix=%20/%2024&width=120)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Functions](https://appwrite.io/docs/references/1.5.x/server-rest/functions#list) | ❌ | ⬛ |
| [Create Function](https://appwrite.io/docs/references/1.5.x/server-rest/functions#create) | ❌ | ⬛ |
| [List Runtimes](https://appwrite.io/docs/references/1.5.x/server-rest/functions#listRuntimes) | ❌ | ⬛ |
| [Get Function](https://appwrite.io/docs/references/1.5.x/server-rest/functions#get) | ❌ | ⬛ |
| [Update Function](https://appwrite.io/docs/references/1.5.x/server-rest/functions#update) | ❌ | ⬛ |
| [Delete Function](https://appwrite.io/docs/references/1.5.x/server-rest/functions#delete) | ❌ | ⬛ |
| [List Deployments](https://appwrite.io/docs/references/1.5.x/server-rest/functions#listDeployments) | ❌ | ⬛ |
| [Create Deployment](https://appwrite.io/docs/references/1.5.x/server-rest/functions#createDeployment) | ❌ | ⬛ |
| [Get Deployment](https://appwrite.io/docs/references/1.5.x/server-rest/functions#getDeployment) | ❌ | ⬛ |
| [Update Function Deployment](https://appwrite.io/docs/references/1.5.x/server-rest/functions#updateDeployment) | ❌ | ⬛ |
| [Delete Deployment](https://appwrite.io/docs/references/1.5.x/server-rest/functions#deleteDeployment) | ❌ | ⬛ |
| [Create Build](https://appwrite.io/docs/references/1.5.x/server-rest/functions#createBuild) | ❌ | ⬛ |
| [Download Deployment](https://appwrite.io/docs/references/1.5.x/server-rest/functions#downloadDeployment) | ❌ | ⬛ |
| [List Executions](https://appwrite.io/docs/references/1.5.x/client-rest/functions#listExecutions) | ⬛ | ⬛ |
| [Create Execution](https://appwrite.io/docs/references/1.5.x/client-rest/functions#createExecution) | ⬛ | ⬛ |
| [Get Execution](https://appwrite.io/docs/references/1.5.x/client-rest/functions#getExecution) | ⬛ | ⬛ |
| [List Variables](https://appwrite.io/docs/references/1.5.x/server-rest/functions#listVariables) | ❌ | ⬛ |
| [Create Variable](https://appwrite.io/docs/references/1.5.x/server-rest/functions#createVariable) | ❌ | ⬛ |
| [Get Variable](https://appwrite.io/docs/references/1.5.x/server-rest/functions#getVariable) | ❌ | ⬛ |
| [Update Variable](https://appwrite.io/docs/references/1.5.x/server-rest/functions#updateVariable) | ❌ | ⬛ |
| [Delete Variable](https://appwrite.io/docs/references/1.5.x/server-rest/functions#deleteVariable) | ❌ | ⬛ |

## Messaging
![0 / 48](https://progress-bar.dev/0/?scale=48&suffix=%20/%2048&width=120)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Messages](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#listMessages) | ❌ | ⬛ |
| [Create Email](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createEmail) | ❌ | ⬛ |
| [Update Email](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateEmail) | ❌ | ⬛ |
| [Create Push Notification](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createPush) | ❌ | ⬛ |
| [Update Push Notification](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updatePush) | ❌ | ⬛ |
| [Create SMS](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createSms) | ❌ | ⬛ |
| [Update SMS](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateSms) | ❌ | ⬛ |
| [Get Message](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#getMessage) | ❌ | ⬛ |
| [Delete Message](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#delete) | ❌ | ⬛ |
| [List Message Logs](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#listMessageLogs) | ❌ | ⬛ |
| [List Message Targets](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#listTargets) | ❌ | ⬛ |
| [List Providers](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#listProviders) | ❌ | ⬛ |
| [Create APNS Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createApnsProvider) | ❌ | ⬛ |
| [Update APNS Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateApnsProvider) | ❌ | ⬛ |
| [Create FCM Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createFcmProvider) | ❌ | ⬛ |
| [Update FCM Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateFcmProvider) | ❌ | ⬛ |
| [Create Mailgun Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createMailgunProvider) | ❌ | ⬛ |
| [Update Mailgun Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateMailgunProvider) | ❌ | ⬛ |
| [Create Msg91 Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createMsg91Provider) | ❌ | ⬛ |
| [Update Msg91 Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateMsg91Provider) | ❌ | ⬛ |
| [Create Sendgrid Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createSendgridProvider) | ❌ | ⬛ |
| [Update Sendgrid Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateSendgridProvider) | ❌ | ⬛ |
| [Create SMTP Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createSmtpProvider) | ❌ | ⬛ |
| [Update SMTP Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateSmtpProvider) | ❌ | ⬛ |
| [Create Telesign Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createTelesignProvider) | ❌ | ⬛ |
| [Update Telesign Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateTelesignProvider) | ❌ | ⬛ |
| [Create Textmagic Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createTextmagicProvider) | ❌ | ⬛ |
| [Update Textmagic Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateTextmagicProvider) | ❌ | ⬛ |
| [Create Twilio Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createTwilioProvider) | ❌ | ⬛ |
| [Update Twilio Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateTwilioProvider) | ❌ | ⬛ |
| [Create Vonage Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createVonageProvider) | ❌ | ⬛ |
| [Update Vonage Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateVonageProvider) | ❌ | ⬛ |
| [Get Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#getProvider) | ❌ | ⬛ |
| [Delete Provider](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#deleteProvider) | ❌ | ⬛ |
| [List Provider Logs](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#listProviderLogs) | ❌ | ⬛ |
| [List Subscriber Logs](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#listSubscriberLogs) | ❌ | ⬛ |
| [List Topics](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#listTopics) | ❌ | ⬛ |
| [Create Topic](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#createTopic) | ❌ | ⬛ |
| [Get Topic](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#getTopic) | ❌ | ⬛ |
| [Update Topic](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#updateTopic) | ❌ | ⬛ |
| [Delete Topic](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#deleteTopic) | ❌ | ⬛ |
| [List Topic Logs](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#listTopicLogs) | ❌ | ⬛ |
| [List Subscribers](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#listSubscribers) | ❌ | ⬛ |
| [Create Subscriber](https://appwrite.io/docs/references/1.5.x/client-rest/messaging#createSubscriber) | ⬛ | ⬛ |
| [Get Subscriber](https://appwrite.io/docs/references/1.5.x/server-rest/messaging#getSubscriber) | ❌ | ⬛ |
| [Delete Subscriber](https://appwrite.io/docs/references/1.5.x/client-rest/messaging#deleteSubscriber) | ⬛ | ⬛ |

## Locale
![0 / 15](https://progress-bar.dev/0/?scale=15&suffix=%20/%2015&width=120)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [Get User Locale](https://appwrite.io/docs/references/1.5.x/client-rest/locale#get) | ⬛ | ❌ |
| [List Locale Codes](https://appwrite.io/docs/references/1.5.x/client-rest/locale#listCodes) | ⬛ | ⬛ |
| [List Continents](https://appwrite.io/docs/references/1.5.x/client-rest/locale#listContinents) | ⬛ | ⬛ |
| [List Countries](https://appwrite.io/docs/references/1.5.x/client-rest/locale#listCountries) | ⬛ | ⬛ |
| [List EU Countries](https://appwrite.io/docs/references/1.5.x/client-rest/locale#listCountriesEU) | ⬛ | ⬛ |
| [List Countries Phone Codes](https://appwrite.io/docs/references/1.5.x/client-rest/locale#listCountriesPhones) | ⬛ | ⬛ |
| [List Currencies](https://appwrite.io/docs/references/1.5.x/client-rest/locale#listCurrencies) | ⬛ | ⬛ |
| [List Languages](https://appwrite.io/docs/references/1.5.x/client-rest/locale#listLanguages) | ⬛ | ⬛ |

## Avatars
![0 / 14](https://progress-bar.dev/0/?scale=14&suffix=%20/%2014&width=120)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [Get Browser Icon](https://appwrite.io/docs/references/1.5.x/client-rest/avatars#getBrowser) | ⬛ | ⬛ |
| [Get Credit Card Icon](https://appwrite.io/docs/references/1.5.x/client-rest/avatars#getCreditCard) | ⬛ | ⬛ |
| [Get Favicon](https://appwrite.io/docs/references/1.5.x/client-rest/avatars#getFavicon) | ⬛ | ⬛ |
| [Get Country Flag](https://appwrite.io/docs/references/1.5.x/client-rest/avatars#getFlag) | ⬛ | ⬛ |
| [Get Image From Url](https://appwrite.io/docs/references/1.5.x/client-rest/avatars#getImage) | ⬛ | ⬛ |
| [Get Initials](https://appwrite.io/docs/references/1.5.x/client-rest/avatars#getInitials) | ⬛ | ⬛ |
| [Get QR Code](https://appwrite.io/docs/references/1.5.x/client-rest/avatars#getQR) | ⬛ | ⬛ |
