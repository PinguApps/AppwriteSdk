using FluentValidation;
using PinguApps.Appwrite.Shared.Requests;

namespace PinguApps.Appwrite.Shared.Tests.Requests;
public class UpdateNameRequestTests
{
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateNameRequest();

        // Assert
        Assert.NotNull(request.Name);
        Assert.Equal(string.Empty, request.Name);
    }

    [Theory]
    [InlineData("name1")]
    [InlineData("name2")]
    public void Properties_CanBeSet(string name)
    {
        // Arrange
        var request = new UpdateNameRequest();

        // Act
        request.Name = name;

        // Assert
        Assert.Equal(name, request.Name);
    }

    [Theory]
    [InlineData("John")]
    [InlineData("John Smith")]
    public void IsValid_WithValidData_ReturnsTrue(string name)
    {
        // Arrange
        var request = new UpdateNameRequest
        {
            Name = name
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("")]
    public void IsValid_WithInvalidData_ReturnsFalse(string name)
    {
        // Arrange
        var request = new UpdateNameRequest
        {
            Name = name
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new UpdateNameRequest
        {
            Name = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateNameRequest
        {
            Name = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
