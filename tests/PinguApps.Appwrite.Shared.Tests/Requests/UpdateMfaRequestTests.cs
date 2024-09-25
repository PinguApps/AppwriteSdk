using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class UpdateMfaRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateMfaRequest();

        // Assert
        Assert.False(request.MfaEnabled);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = new UpdateMfaRequest();

        // Act
        request.MfaEnabled = true;

        // Assert
        Assert.True(request.MfaEnabled);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void IsValid_WithValidData_ReturnsTrue(bool mfaEnabled)
    {
        // Arrange
        var request = new UpdateMfaRequest
        {
            MfaEnabled = mfaEnabled
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }
}
