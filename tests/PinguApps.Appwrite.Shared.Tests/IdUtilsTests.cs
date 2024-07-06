using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests;
public class IdUtilsTests
{
    [Fact]
    public void GetHexTimestamp_Returns_ValidHexFormat()
    {
        // Act
        var hexTimestamp = IdUtils.GetHexTimestamp();

        // Assert
        Assert.Matches("^[a-fA-F0-9]+$", hexTimestamp);
    }

    [Fact]
    public void GetHexTimestamp_Returns_ExpectedLength()
    {
        // Act
        var hexTimestamp = IdUtils.GetHexTimestamp();

        // Assert
        // Assuming the length is the hex representation of seconds (at least 5 chars) plus 5 chars of milliseconds
        Assert.True(hexTimestamp.Length >= 10);
    }

    [Theory]
    [InlineData(5)]
    [InlineData(7)]
    [InlineData(10)]
    public void GenerateUniqueId_WithPadding_Returns_CorrectLength(int padding)
    {
        // Act
        var uniqueId = IdUtils.GenerateUniqueId(padding);

        // Assert
        // Length of the base ID plus the padding
        var expectedLength = IdUtils.GetHexTimestamp().Length + padding;
        Assert.Equal(expectedLength, uniqueId.Length);
    }

    [Fact]
    public void GenerateUniqueId_WithoutPadding_Returns_DefaultLength()
    {
        // Act
        var uniqueId = IdUtils.GenerateUniqueId();

        // Assert
        // Default padding is 7
        var expectedLength = IdUtils.GetHexTimestamp().Length + 7;
        Assert.Equal(expectedLength, uniqueId.Length);
    }

    [Fact]
    public void GenerateUniqueId_Returns_UniqueValues()
    {
        // Act
        var id1 = IdUtils.GenerateUniqueId();
        var id2 = IdUtils.GenerateUniqueId();

        // Assert
        Assert.NotEqual(id1, id2);
    }
}
