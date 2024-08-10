using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class MfaRecoveryCodesTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var code1 = "a3kf0-s0cl2";
        var code2 = "s0co1-as98s";

        // Act
        var mfaFactors = new MfaRecoveryCodes([code1, code2]);

        // Assert
        Assert.Collection(mfaFactors.RecoveryCodes, x => Assert.Equal(code1, x), x => Assert.Equal(code2, x));
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var mfaFactors = JsonSerializer.Deserialize<MfaFactors>(Constants.MfaFactorsResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(mfaFactors);
        Assert.True(mfaFactors.Totp);
        Assert.True(mfaFactors.Phone);
        Assert.True(mfaFactors.Email);
        Assert.True(mfaFactors.RecoveryCode);
    }
}
