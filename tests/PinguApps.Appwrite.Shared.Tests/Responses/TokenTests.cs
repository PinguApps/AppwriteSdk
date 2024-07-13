using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class TokenTests
{

    [Fact]
    public void Token_Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var id = "testId";
        var createdAt = DateTime.UtcNow;
        var userId = "userId";
        var secret = "secret token";
        var expiresAt = DateTime.UtcNow;
        var phrase = "phrase";


        // Act
        var token = new Token(id, createdAt, userId, secret, expiresAt, phrase);

        // Assert
        Assert.Equal(id, token.Id);
        Assert.Equal(createdAt, token.CreatedAt);
        Assert.Equal(userId, token.UserId);
        Assert.Equal(secret, token.Secret);
        Assert.Equal(expiresAt, token.ExpiresAt);
        Assert.Equal(phrase, token.Phrase);
    }

    [Fact]
    public void Token_CanBeDeserialized_FromJson()
    {
        // Act
        var token = JsonSerializer.Deserialize<Token>(Constants.TokenResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(token);
        Assert.Equal("bb8ea5c16897e", token.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), token.CreatedAt.ToUniversalTime());
        Assert.Equal("5e5ea5c168bb8", token.UserId);
        Assert.Equal("secret", token.Secret);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), token.ExpiresAt.ToUniversalTime());
        Assert.Equal("Golden Fox", token.Phrase);
    }
}
