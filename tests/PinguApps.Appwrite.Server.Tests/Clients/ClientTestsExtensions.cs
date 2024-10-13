using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Server.Tests.Clients;

public static class ClientTestsExtensions
{
    public static MockedRequest ExpectedHeaders(this MockedRequest request)
    {
        return request
            .WithHeaders("x-appwrite-project", TestConstants.ProjectId)
            .WithHeaders("x-appwrite-key", TestConstants.ApiKey)
            .WithHeaders("x-sdk-name", TestConstants.SdkName)
            .WithHeaders("x-sdk-platform", "server")
            .WithHeaders("x-sdk-language", TestConstants.SdkLanguage)
            .WithHeaders("x-sdk-version", Constants.Version)
            .WithHeaders("x-appwrite-response-format", TestConstants.AppwriteResponseFormat);
    }
}
