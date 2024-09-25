using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;

public static class AccountTestsExtensions
{
    public static MockedRequest ExpectedHeaders(this MockedRequest request, bool addSessionHeaders = false)
    {
        var req = request
            .WithHeaders("x-appwrite-project", Constants.ProjectId)
            .WithHeaders("x-sdk-name", Constants.SdkName)
            .WithHeaders("x-sdk-platform", "client")
            .WithHeaders("x-sdk-language", Constants.SdkLanguage)
            .WithHeaders("x-sdk-version", Constants.SdkVersion)
            .WithHeaders("x-appwrite-response-format", Constants.AppwriteResponseFormat);

        if (addSessionHeaders)
            return req.ExpectSessionHeaders();

        return req;
    }

    public static MockedRequest ExpectSessionHeaders(this MockedRequest request)
    {
        return request
            .WithHeaders("x-appwrite-session", Constants.Session);
    }
}
