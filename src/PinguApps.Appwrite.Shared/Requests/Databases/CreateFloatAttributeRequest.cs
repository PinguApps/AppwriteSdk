﻿using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// The request to create a float attribute
/// </summary>
public class CreateFloatAttributeRequest : CreateAttributeBaseRequest<CreateFloatAttributeRequest, CreateFloatAttributeRequestValidator>
{
    /// <summary>
    /// Default value for attribute when not provided. Cannot be set when attribute is required
    /// </summary>
    [JsonPropertyName("default")]
    public double? Default { get; set; }

    /// <summary>
    /// Minimum value to enforce on new documents
    /// </summary>
    [JsonPropertyName("min")]
    public double? Min { get; set; }

    /// <summary>
    /// Maximum value to enforce on new documents
    /// </summary>
    [JsonPropertyName("max")]
    public double? Max { get; set; }
}
