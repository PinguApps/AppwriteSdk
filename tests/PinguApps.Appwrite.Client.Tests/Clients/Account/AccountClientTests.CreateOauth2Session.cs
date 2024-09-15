﻿using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
public partial class AccountClientTests
{
    [Fact]
    public void CreateOauth2Session_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateOauth2SessionRequest()
        {
            Provider = "google"
        };

        // Act
        var result = _appwriteClient.Account.CreateOauth2Session(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public void CreateOauth2Session_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateOauth2SessionRequest()
        {
            Provider = ""
        };

        // Act
        var result = _appwriteClient.Account.CreateOauth2Session(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
    }
}