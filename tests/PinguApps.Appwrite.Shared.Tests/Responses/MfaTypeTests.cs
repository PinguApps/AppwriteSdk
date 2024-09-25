using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class MfaTypeTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var secret = "The_Secret";
        var uri = "otpauth://totp/Appwrite%20Test%3Apingu%40appwrite.com?issuer=Appwrite%20Test&secret=The_Secret";

        // Act
        var mfaType = new MfaType(secret, uri);

        // Assert
        Assert.Equal(secret, mfaType.Secret);
        Assert.Equal(uri, mfaType.Uri);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var mfaType = JsonSerializer.Deserialize<MfaType>(Constants.MfaTypeResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(mfaType);
        Assert.Equal("The_Secret", mfaType.Secret);
        Assert.Equal("otpauth://totp/Appwrite%20Test%3Apingu%40appwrite.com?issuer=Appwrite%20Test&secret=The_Secret", mfaType.Uri);
    }
}
