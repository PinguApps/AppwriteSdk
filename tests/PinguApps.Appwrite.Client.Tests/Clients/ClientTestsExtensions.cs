﻿using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Tests;
using RichardSzalay.MockHttp;

namespace PinguApps.Appwrite.Client.Tests.Clients;

public static class ClientTestsExtensions
{
    public static MockedRequest ExpectedHeaders(this MockedRequest request, bool addSessionHeaders = false)
    {
        var req = request
            .WithHeaders("x-appwrite-project", TestConstants.ProjectId)
            .WithHeaders("x-sdk-name", TestConstants.SdkName)
            .WithHeaders("x-sdk-platform", "client")
            .WithHeaders("x-sdk-language", TestConstants.SdkLanguage)
            .WithHeaders("x-sdk-version", Constants.Version)
            .WithHeaders("x-appwrite-response-format", TestConstants.AppwriteResponseFormat);

        if (addSessionHeaders)
            return req.ExpectSessionHeaders();

        return req;
    }

    public static MockedRequest ExpectSessionHeaders(this MockedRequest request)
    {
        return request
            .WithHeaders("x-appwrite-session", TestConstants.Session);
    }
}
