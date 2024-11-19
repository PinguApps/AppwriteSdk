﻿using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;
public class CreateBooleanAttributeRequest : CreateAttributeBaseRequest<CreateBooleanAttributeRequest, CreateBooleanAttributeRequestValidator>
{
    /// <summary>
    /// Default value for attribute when not provided. Cannot be set when attribute is required
    /// </summary>
    [JsonPropertyName("default")]
    public bool? Default { get; set; }
}