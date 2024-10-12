using System.Collections.Generic;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Attributes;
using PinguApps.Appwrite.Shared.Requests.Account.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account;

/// <summary>
/// The request for creating an Oauth2 token
/// </summary>
public class CreateOauth2TokenRequest : QueryParamBaseRequest<CreateOauth2TokenRequest, CreateOauth2TokenRequestValidator>
{
    /// <summary>
    /// OAuth2 Provider. Currently, supported providers are:
    /// <para>amazon, apple, auth0, authentik, autodesk, bitbucket, bitly, box, dailymotion, discord, disqus, dropbox, etsy, facebook, github, gitlab, google, linkedin, microsoft, notion, oidc, okta, paypal, paypalSandbox, podio, salesforce, slack, spotify, stripe, tradeshift, tradeshiftBox, twitch, wordpress, yahoo, yammer, yandex, zoho, zoom</para>
    /// </summary>
    [UrlReplacement("{provider}")]
    [JsonPropertyName("_provider")]
    public string Provider { get; set; } = string.Empty;

    /// <summary>
    /// URL to redirect back to your app after a successful login attempt. Only URLs from hostnames in your project's platform list are allowed. This requirement helps to prevent an <see href="https://cheatsheetseries.owasp.org/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.html">open redirect</see> attack against your project API
    /// </summary>
    [QueryParameter("success")]
    [JsonPropertyName("_success")]
    public string? SuccessUri { get; set; }

    /// <summary>
    /// URL to redirect back to your app after a failed login attempt. Only URLs from hostnames in your project's platform list are allowed. This requirement helps to prevent an <see href="https://cheatsheetseries.owasp.org/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.html">open redirect</see> attack against your project API
    /// </summary>
    [QueryParameter("failure")]
    [JsonPropertyName("_failure")]
    public string? FailureUri { get; set; }

    /// <summary>
    /// A list of custom OAuth2 scopes. Check each provider internal docs for a list of supported scopes. Maximum of 100 scopes are allowed, each 4096 characters long
    /// </summary>
    [QueryParameter("scopes[]")]
    [JsonPropertyName("_scopes")]
    public List<string>? Scopes { get; set; }

    protected override string Path => "/account/tokens/oauth2/{provider}";
}
