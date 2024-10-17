using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class UpdateNameRequestTests : TeamIdBaseRequestTests<UpdateNameRequest, UpdateNameRequestValidator>
{
    protected override UpdateNameRequest CreateValidRequest => new()
    {
        Name = "Pingu"
    };
    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateNameRequest();

        // Assert
        Assert.Equal(string.Empty, request.Name);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var name = "Updated Team Name";

        var request = new UpdateNameRequest();

        // Act
        request.Name = name;

        // Assert
        Assert.Equal(name, request.Name);
    }

    public static TheoryData<UpdateNameRequest> ValidRequestsData = new()
    {
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = "Valid Team Name"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = "Another Valid Team"
        }
    };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateNameRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateNameRequest> InvalidRequestsData = new()
    {
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = null!
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = ""
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Name = new string('a', 129)
        }
    };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateNameRequest request)
    {
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
            TeamId = IdUtils.GenerateUniqueId(),
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
            TeamId = IdUtils.GenerateUniqueId(),
            Name = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
