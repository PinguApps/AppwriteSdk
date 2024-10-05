using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients;

public static class ClientTestsExtensions
{
    public static MockedRequest ExpectedHeaders(this MockedRequest request)
    {
        return request
            .WithHeaders("x-appwrite-project", Constants.ProjectId)
            .WithHeaders("x-appwrite-key", Constants.ApiKey)
            .WithHeaders("x-sdk-name", Constants.SdkName)
            .WithHeaders("x-sdk-platform", "server")
            .WithHeaders("x-sdk-language", Constants.SdkLanguage)
            .WithHeaders("x-sdk-version", Constants.SdkVersion)
            .WithHeaders("x-appwrite-response-format", Constants.AppwriteResponseFormat);
    }
}
