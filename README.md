# AppwriteClient

## Key
| Icon | Definition |
|:-:|:-:|
| ✅ | The endpoint is implemented for the given SDK type (client or server) |
| ⬛ | The endpoint is not yet implemented for the given SDK type (client or server), but will be |
| ❌ | There is currently no intention to implement the endpoint for the given SDK type (client or server) |

## Account
![0%](https://progress-bar.dev/0)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [Get Account](https://appwrite.io/docs/references/cloud/client-rest/account#get) | ⬛ | ❌ |
| [Create Account](https://appwrite.io/docs/references/cloud/client-rest/account#create) |  |  |
| [Update Email](https://appwrite.io/docs/references/cloud/client-rest/account#updateEmail) |  |  |
| [List Identities](https://appwrite.io/docs/references/cloud/client-rest/account#listIdentities) |  |  |
| [Delete Identity](https://appwrite.io/docs/references/cloud/client-rest/account#deleteIdentity) |  |  |
| [Create JWT](https://appwrite.io/docs/references/cloud/client-rest/account#createJWT) |  |  |
| [List Logs](https://appwrite.io/docs/references/cloud/client-rest/account#listLogs) |  |  |
| [Update MFA](https://appwrite.io/docs/references/cloud/client-rest/account#updateMFA) |  |  |
| [Add Authenticator](https://appwrite.io/docs/references/cloud/client-rest/account#createMfaAuthenticator) |  |  |
| [Verify Authenticator](https://appwrite.io/docs/references/cloud/client-rest/account#updateMfaAuthenticator) |  |  |
| [Delete Authenticator](https://appwrite.io/docs/references/cloud/client-rest/account#deleteMfaAuthenticator) |  |  |
| [Create 2FA Challenge](https://appwrite.io/docs/references/cloud/client-rest/account#createMfaChallenge) |  |  |
| [Create MFA Challenge (confirmation)](https://appwrite.io/docs/references/cloud/client-rest/account#updateMfaChallenge) |  |  |
| [List Factors](https://appwrite.io/docs/references/cloud/client-rest/account#listMfaFactors) |  |  |
| [Get MFA Recovery Codes](https://appwrite.io/docs/references/cloud/client-rest/account#getMfaRecoveryCodes) |  |  |
| [Create MFA Recovery Codes](https://appwrite.io/docs/references/cloud/client-rest/account#createMfaRecoveryCodes) |  |  |
| [Regenerate MFA Recovery Codes](https://appwrite.io/docs/references/cloud/client-rest/account#updateMfaRecoveryCodes) |  |  |
| [Update Name](https://appwrite.io/docs/references/cloud/client-rest/account#updateName) |  |  |
| [Update Password](https://appwrite.io/docs/references/cloud/client-rest/account#updatePassword) |  |  |
| [Update Phone](https://appwrite.io/docs/references/cloud/client-rest/account#updatePhone) |  |  |
| [Get Account Preferences](https://appwrite.io/docs/references/cloud/client-rest/account#getPrefs) |  |  |
| [Update Preferences](https://appwrite.io/docs/references/cloud/client-rest/account#updatePrefs) |  |  |
| [Create Password Recovery](https://appwrite.io/docs/references/cloud/client-rest/account#createRecovery) |  |  |
| [Create Password Recovery (Confirmation)](https://appwrite.io/docs/references/cloud/client-rest/account#updateRecovery) |  |  |
| [List Sessions](https://appwrite.io/docs/references/cloud/client-rest/account#listSessions) |  |  |
| [Delete Sessions](https://appwrite.io/docs/references/cloud/client-rest/account#deleteSessions) |  |  |
| [Create Anonymous Session](https://appwrite.io/docs/references/cloud/client-rest/account#createAnonymousSession) |  |  |
| [Create Email Password Session](https://appwrite.io/docs/references/cloud/client-rest/account#createEmailPasswordSession) |  |  |
| [Update Magic URL Session](https://appwrite.io/docs/references/cloud/client-rest/account#updateMagicURLSession) |  |  |
| [Create OAuth2 Session](https://appwrite.io/docs/references/cloud/client-rest/account#createOAuth2Session) |  | ❌ |
| [Update Phone Session](https://appwrite.io/docs/references/cloud/client-rest/account#updatePhoneSession) |  |  |
| [Create Session](https://appwrite.io/docs/references/cloud/client-rest/account#createSession) |  |  |
| [Get Session](https://appwrite.io/docs/references/cloud/client-rest/account#getSession) |  |  |
| [Update Session](https://appwrite.io/docs/references/cloud/client-rest/account#updateSession) |  |  |
| [Delete Session](https://appwrite.io/docs/references/cloud/client-rest/account#deleteSession) |  |  |
| [Update Status](https://appwrite.io/docs/references/cloud/client-rest/account#updateStatus) |  |  |
| [Create Push Target](https://appwrite.io/docs/references/cloud/client-rest/account#createPushTarget) |  | ❌ |
| [Update Push Target](https://appwrite.io/docs/references/cloud/client-rest/account#updatePushTarget) |  | ❌ |
| [Delete Push Target](https://appwrite.io/docs/references/cloud/client-rest/account#deletePushTarget) |  | ❌ |
| [Create Email Token (OTP)](https://appwrite.io/docs/references/cloud/client-rest/account#createEmailToken) |  |  |
| [Create Magic URL Token](https://appwrite.io/docs/references/cloud/client-rest/account#createMagicURLToken) |  |  |
| [Create OAuth2 Token](https://appwrite.io/docs/references/cloud/client-rest/account#createOAuth2Token) |  |  |
| [Create Phone Token](https://appwrite.io/docs/references/cloud/client-rest/account#createPhoneToken) |  |  |
| [Create Email Verification](https://appwrite.io/docs/references/cloud/client-rest/account#createVerification) |  |  |
| [Create Email Verification (Confirmation)](https://appwrite.io/docs/references/cloud/client-rest/account#updateVerification) |  |  |
| [Create Phone Verification](https://appwrite.io/docs/references/cloud/client-rest/account#createPhoneVerification) |  |  |
| [Create Phone Verification (Confirmation)](https://appwrite.io/docs/references/cloud/client-rest/account#updatePhoneVerification) |  |  |

## Users
![0%](https://progress-bar.dev/0)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Users](https://appwrite.io/docs/references/cloud/server-rest/users#list) | ❌ | ⬛ |
| [Create User](https://appwrite.io/docs/references/cloud/server-rest/users#create) | ❌ | ⬛ |
| [Create User with Argon2 Password](https://appwrite.io/docs/references/cloud/server-rest/users#createArgon2User) | ❌ | ⬛ |
| [Create User with Bcrypt Password](https://appwrite.io/docs/references/cloud/server-rest/users#createBcryptUser) | ❌ | ⬛ |
| [List Identities](https://appwrite.io/docs/references/cloud/server-rest/users#listIdentities) | ❌ | ⬛ |
| [Delete Identity](https://appwrite.io/docs/references/cloud/server-rest/users#deleteIdentity) | ❌ | ⬛ |
| [Create User with MD5 Password](https://appwrite.io/docs/references/cloud/server-rest/users#createMD5User) | ❌ | ⬛ |
| [Create User with PHPass Password](https://appwrite.io/docs/references/cloud/server-rest/users#createPHPassUser) | ❌ | ⬛ |
| [Create User with Scrypt Password](https://appwrite.io/docs/references/cloud/server-rest/users#createScryptUser) | ❌ | ⬛ |
| [Create User with Scrypt Modified Password](https://appwrite.io/docs/references/cloud/server-rest/users#createScryptModifiedUser) | ❌ | ⬛ |
| [Create User with SHA Password](https://appwrite.io/docs/references/cloud/server-rest/users#createSHAUser) | ❌ | ⬛ |
| [Get User](https://appwrite.io/docs/references/cloud/server-rest/users#get) | ❌ | ⬛ |
| [Delete User](https://appwrite.io/docs/references/cloud/server-rest/users#delete) | ❌ | ⬛ |
| [Update Email](https://appwrite.io/docs/references/cloud/server-rest/users#updateEmail) | ❌ | ⬛ |
| [Update User Labels](https://appwrite.io/docs/references/cloud/server-rest/users#updateLabels) | ❌ | ⬛ |
| [List User Logs](https://appwrite.io/docs/references/cloud/server-rest/users#listLogs) | ❌ | ⬛ |
| [List User Memberships](https://appwrite.io/docs/references/cloud/server-rest/users#listMemberships) | ❌ | ⬛ |
| [Update MFA](https://appwrite.io/docs/references/cloud/server-rest/users#updateMfa) | ❌ | ⬛ |
| [Delete Authenticator](https://appwrite.io/docs/references/cloud/server-rest/users#deleteMfaAuthenticator) | ❌ | ⬛ |
| [List Factors](https://appwrite.io/docs/references/cloud/server-rest/users#listMfaFactors) | ❌ | ⬛ |
| [Get MFA Recovery Codes](https://appwrite.io/docs/references/cloud/server-rest/users#getMfaRecoveryCodes) | ❌ | ⬛ |
| [Regenerator MFA Recovery Codes](https://appwrite.io/docs/references/cloud/server-rest/users#updateMfaRecoveryCodes) | ❌ | ⬛ |
| [Create MFA Recovery Codes](https://appwrite.io/docs/references/cloud/server-rest/users#createMfaRecoveryCodes) | ❌ | ⬛ |
| [Update Name](https://appwrite.io/docs/references/cloud/server-rest/users#updateName) | ❌ | ⬛ |
| [Update Password](https://appwrite.io/docs/references/cloud/server-rest/users#updatePassword) | ❌ | ⬛ |
| [Update Phone](https://appwrite.io/docs/references/cloud/server-rest/users#updatePhone) | ❌ | ⬛ |
| [Get User Preferences](https://appwrite.io/docs/references/cloud/server-rest/users#getPrefs) | ❌ | ⬛ |
| [Update User Preferences](https://appwrite.io/docs/references/cloud/server-rest/users#updatePrefs) | ❌ | ⬛ |
| [List User Sessions](https://appwrite.io/docs/references/cloud/server-rest/users#listSessions) | ❌ | ⬛ |
| [Create Session](https://appwrite.io/docs/references/cloud/server-rest/users#createSession) | ❌ | ⬛ |
| [Delete User Sessions](https://appwrite.io/docs/references/cloud/server-rest/users#deleteSessions) | ❌ | ⬛ |
| [Delete User Session](https://appwrite.io/docs/references/cloud/server-rest/users#deleteSession) | ❌ | ⬛ |
| [Update User Status](https://appwrite.io/docs/references/cloud/server-rest/users#updateStatus) | ❌ | ⬛ |
| [List User Targets](https://appwrite.io/docs/references/cloud/server-rest/users#listTargets) | ❌ | ⬛ |
| [Create User Target](https://appwrite.io/docs/references/cloud/server-rest/users#createTarget) | ❌ | ⬛ |
| [Get User Target](https://appwrite.io/docs/references/cloud/server-rest/users#getTarget) | ❌ | ⬛ |
| [Update User Target](https://appwrite.io/docs/references/cloud/server-rest/users#updateTarget) | ❌ | ⬛ |
| [Delete User Target](https://appwrite.io/docs/references/cloud/server-rest/users#deleteTarget) | ❌ | ⬛ |
| [Create Token](https://appwrite.io/docs/references/cloud/server-rest/users#createToken) | ❌ | ⬛ |
| [Update Email Verification](https://appwrite.io/docs/references/cloud/server-rest/users#updateEmailVerification) | ❌ | ⬛ |
| [Update Phone Verification](https://appwrite.io/docs/references/cloud/server-rest/users#updatePhoneVerification) | ❌ | ⬛ |

## Teams
![0%](https://progress-bar.dev/0)

| Endpoint | Client | Server |
|:-:|:-:|:-:|
| [List Teams](https://appwrite.io/docs/references/cloud/client-rest/teams#list) |  |  |
| [Create Team](https://appwrite.io/docs/references/cloud/client-rest/teams#create) |  |  |
| [Get Team](https://appwrite.io/docs/references/cloud/client-rest/teams#get) |  |  |
| [Updatet Name](https://appwrite.io/docs/references/cloud/client-rest/teams#updateName) |  |  |
| [Delete Team](https://appwrite.io/docs/references/cloud/client-rest/teams#delete) |  |  |
| [List Team Memberships](https://appwrite.io/docs/references/cloud/client-rest/teams#listMemberships) |  |  |
| [Create Team Membership](https://appwrite.io/docs/references/cloud/client-rest/teams#createMembership) |  |  |
| [Get Team Membership](https://appwrite.io/docs/references/cloud/client-rest/teams#getMembership) |  |  |
| [Update Membership](https://appwrite.io/docs/references/cloud/client-rest/teams#updateMembership) |  |  |
| [Delete Team Membership](https://appwrite.io/docs/references/cloud/client-rest/teams#deleteMembership) |  |  |
| [Update Team Membership Status](https://appwrite.io/docs/references/cloud/client-rest/teams#updateMembershipStatus) |  |  |
| [Get Team Memberships](https://appwrite.io/docs/references/cloud/client-rest/teams#getPrefs) |  |  |
| [Update Preferences](https://appwrite.io/docs/references/cloud/client-rest/teams#updatePrefs) |  |  |
