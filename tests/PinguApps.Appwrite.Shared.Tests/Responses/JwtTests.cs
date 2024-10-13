using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class JwtTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var token = "testToken";

        // Act
        var jwt = new Jwt(token);

        // Assert
        Assert.Equal(token, jwt.Token);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var jwt = JsonSerializer.Deserialize<Jwt>(TestConstants.JwtResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(jwt);
        Assert.Equal("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c", jwt.Token);
    }
}
