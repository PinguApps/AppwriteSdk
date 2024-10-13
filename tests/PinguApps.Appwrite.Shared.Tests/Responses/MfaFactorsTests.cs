using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class MfaFactorsTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange

        // Act
        var mfaFactors = new MfaFactors(true, true, true, true);

        // Assert
        Assert.True(mfaFactors.Totp);
        Assert.True(mfaFactors.Phone);
        Assert.True(mfaFactors.Email);
        Assert.True(mfaFactors.RecoveryCode);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var mfaFactors = JsonSerializer.Deserialize<MfaFactors>(TestConstants.MfaFactorsResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(mfaFactors);
        Assert.True(mfaFactors.Totp);
        Assert.True(mfaFactors.Phone);
        Assert.True(mfaFactors.Email);
        Assert.True(mfaFactors.RecoveryCode);
    }
}
