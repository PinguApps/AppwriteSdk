using PinguApps.Appwrite.Shared.Requests.Account;

namespace PinguApps.Appwrite.Server.Tests.Servers.Account;
public partial class AccountClientTests
{
    [Fact]
    public void CreateOauth2Token_ShouldReturnSuccess_WhenApiCallSucceeds()
    {
        // Arrange
        var request = new CreateOauth2TokenRequest()
        {
            Provider = "google"
        };

        // Act
        var result = _appwriteServer.Account.CreateOauth2Token(request);

        // Assert
        Assert.True(result.Success);
    }

    [Fact]
    public void CreateOauth2Token_ShouldReturnErrorResponse_WhenExceptionOccurs()
    {
        // Arrange
        var request = new CreateOauth2TokenRequest()
        {
            Provider = ""
        };

        // Act
        var result = _appwriteServer.Account.CreateOauth2Token(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
    }
}
