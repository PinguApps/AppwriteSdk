using System;
using System.Collections.Generic;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// An Appwrite Session object
/// </summary>
/// <param name="Id">Session ID</param>
/// <param name="CreatedAt">Session creation date in ISO 8601 format</param>
/// <param name="UpdatedAt">Session update date in ISO 8601 format</param>
/// <param name="UserId">User ID</param>
/// <param name="ExpiresAt">Session expiration date in ISO 8601 format</param>
/// <param name="Provider">Session Provider</param>
/// <param name="ProviderId">Session Provider User ID</param>
/// <param name="ProviderAccessToken">Session Provider Access Token</param>
/// <param name="ProviderAccessTokenExpiry">The date of when the access token expires in ISO 8601 format</param>
/// <param name="ProviderRefreshToken">Session Provider Refresh Token</param>
/// <param name="Ip">IP in use when the session was created</param>
/// <param name="OsCode">Operating system code name. View list of <see href="https://github.com/appwrite/appwrite/blob/master/docs/lists/os.json">available options</see></param>
/// <param name="OsName">Operating system name</param>
/// <param name="OsVersion">Operating system version</param>
/// <param name="ClientType">Client type</param>
/// <param name="ClientCode">Client code name. View list of <see href="https://github.com/appwrite/appwrite/blob/master/docs/lists/clients.json">available options</see></param>
/// <param name="ClientName">Client name</param>
/// <param name="ClientVersion">Client version</param>
/// <param name="ClientEngine">Client engine name</param>
/// <param name="ClientEngineVersion">Client engine name</param>
/// <param name="DeviceName">Device name</param>
/// <param name="DeviceBrand">Device brand name</param>
/// <param name="DeviceModel">Device model name</param>
/// <param name="CountryCode">Country two-character ISO 3166-1 alpha code</param>
/// <param name="CountryName">Country name</param>
/// <param name="Current">Returns true if this the current user session</param>
/// <param name="Factors">Returns a list of active session factors</param>
/// <param name="Secret">Secret used to authenticate the user. Only included if the request was made with an API key</param>
/// <param name="MfaUpdatedAt">Most recent date in ISO 8601 format when the session successfully passed MFA challenge</param>
public record Session(
    string Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    string UserId,
    DateTime ExpiresAt,
    string Provider,
    string ProviderId,
    string ProviderAccessToken,
    DateTime? ProviderAccessTokenExpiry,
    string ProviderRefreshToken,
    string Ip,
    string OsCode,
    string OsName,
    string OsVersion,
    string ClientType,
    string ClientCode,
    string ClientName,
    string ClientVersion,
    string ClientEngine,
    string ClientEngineVersion,
    string DeviceName,
    string DeviceBrand,
    string DeviceModel,
    string CountryCode,
    string CountryName,
    bool Current,
    IReadOnlyList<string> Factors,
    string Secret,
    DateTime? MfaUpdatedAt
);
