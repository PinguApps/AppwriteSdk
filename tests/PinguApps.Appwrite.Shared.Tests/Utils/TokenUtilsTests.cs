using System.Text.Json;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Utils;
public class TokenUtilsTests
{
    [Fact]
    public void GetSessionToken_ShouldReturnBase64EncodedString()
    {
        // Arrange
        string userId = "testUser";
        string secret = "testSecret";

        // Act
        string result = TokenUtils.GetSessionToken(userId, secret);

        // Assert
        Assert.NotNull(result);
        var jsonBytes = Convert.FromBase64String(result);
        var session = JsonSerializer.Deserialize<TokenUtils.SessionToken>(jsonBytes);
        Assert.NotNull(session);
        Assert.Equal(userId, session.Id);
        Assert.Equal(secret, session.Secret);
    }
}
