using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Client.Tests.Clients.Account;
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
        var result = _appwriteClient.Account.CreateOauth2Token(request);

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
        var result = _appwriteClient.Account.CreateOauth2Token(request);

        // Assert
        Assert.False(result.Success);
        Assert.True(result.IsInternalError);
    }
}
