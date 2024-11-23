using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to create an enum attribute
/// </summary>
public class CreateEnumAttributeRequest : CreateStringAttributeBaseRequest<CreateEnumAttributeRequest, CreateEnumAttributeRequestValidator>
{
    /// <summary>
    /// Array of elements in enumerated type. Uses length of longest element to determine size. Maximum of 100 elements are allowed, each 255 characters long
    /// </summary>
    [JsonPropertyName("elements")]
    public List<string> Elements { get; set; } = [];
}
