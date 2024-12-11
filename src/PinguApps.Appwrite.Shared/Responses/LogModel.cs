using System;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Responses;

/// <summary>
/// Ann Appwrite Log object
/// </summary>
/// <param name="Event">Event name</param>
/// <param name="UserId">User ID</param>
/// <param name="UserEmail">User Email</param>
/// <param name="UserName">User Name</param>
/// <param name="Mode">API mode when event triggered</param>
/// <param name="Ip">IP session in use when the session was created</param>
/// <param name="Time">Log creation date in ISO 8601 format</param>
/// <param name="OsCode">Operating system code name. View list of <see href="https://github.com/appwrite/appwrite/blob/master/docs/lists/os.json">Available Options</see></param>
/// <param name="OsName">Operating system name</param>
/// <param name="OsVersion">Operating system version</param>
/// <param name="ClientType">Client type</param>
/// <param name="ClientCode">Client code name. View list of <see href="https://github.com/appwrite/appwrite/blob/master/docs/lists/clients.json">Available Options</see></param>
/// <param name="ClientName">Client name</param>
/// <param name="ClientVersion">Client version</param>
/// <param name="ClientEngine">Client engine name</param>
/// <param name="ClientEngineVersion">Client engine version</param>
/// <param name="DeviceName">Device name</param>
/// <param name="DeviceBrand">Device brand name</param>
/// <param name="DeviceModel">Device model name</param>
/// <param name="CountryCode">Country two-character ISO 3166-1 alpha code</param>
/// <param name="CountryName">Country name</param>
public record LogModel(
    [property: JsonPropertyName("event")] string Event,
    [property: JsonPropertyName("userId")] string UserId,
    [property: JsonPropertyName("userEmail")] string UserEmail,
    [property: JsonPropertyName("userName")] string UserName,
    [property: JsonPropertyName("mode")] string Mode,
    [property: JsonPropertyName("ip")] string Ip,
    [property: JsonPropertyName("time"), JsonConverter(typeof(MultiFormatDateTimeConverter))] DateTime Time,
    [property: JsonPropertyName("osCode")] string OsCode,
    [property: JsonPropertyName("osName")] string OsName,
    [property: JsonPropertyName("osVersion")] string OsVersion,
    [property: JsonPropertyName("clientType")] string ClientType,
    [property: JsonPropertyName("clientCode")] string ClientCode,
    [property: JsonPropertyName("clientName")] string ClientName,
    [property: JsonPropertyName("clientVersion")] string ClientVersion,
    [property: JsonPropertyName("clientEngine")] string ClientEngine,
    [property: JsonPropertyName("clientEngineVersion")] string ClientEngineVersion,
    [property: JsonPropertyName("deviceName")] string DeviceName,
    [property: JsonPropertyName("deviceBrand")] string DeviceBrand,
    [property: JsonPropertyName("deviceModel")] string DeviceModel,
    [property: JsonPropertyName("countryCode")] string CountryCode,
    [property: JsonPropertyName("countryName")] string CountryName
);
