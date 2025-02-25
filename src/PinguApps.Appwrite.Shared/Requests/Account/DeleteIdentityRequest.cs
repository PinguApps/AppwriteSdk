﻿using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for deleting an identity
/// </summary>
public class DeleteIdentityRequest : BaseRequest<DeleteIdentityRequest, DeleteIdentityRequestValidator>
{
    /// <summary>
    /// Identity ID
    /// </summary>
    [JsonPropertyName("identityId")]
    [SdkExclude]
    public string IdentityId { get; set; } = string.Empty;
}
