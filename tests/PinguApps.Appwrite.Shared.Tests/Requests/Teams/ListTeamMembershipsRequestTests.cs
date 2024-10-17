using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class ListTeamMembershipsRequestTests : QuerySearchBaseRequestTests<ListTeamMembershipsRequest, ListTeamMembershipsRequestValidator>
{
    protected override ListTeamMembershipsRequest CreateValidRequest => new()
    {
        TeamId = IdUtils.GenerateUniqueId()
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new ListTeamMembershipsRequest();

        // Assert
        Assert.Equal(string.Empty, request.TeamId);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var teamIdValue = IdUtils.GenerateUniqueId();
        var request = new ListTeamMembershipsRequest();

        // Act
        request.TeamId = teamIdValue;

        // Assert
        Assert.Equal(teamIdValue, request.TeamId);
    }

    [Fact]
    public void IsValid_WithValidTeamId_ReturnsTrue()
    {
        // Arrange
        var request = new ListTeamMembershipsRequest();
        request.TeamId = "valid_Team-Id.";

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("invalid chars!")]
    [InlineData(".startsWithSymbol")]
    [InlineData("ThisIdHasTooManyCharactersAsTheLimitIs36")]
    public void IsValid_WithInvalidData_ReturnsFalse(string? teamId)
    {
        // Arrange
        var request = new ListTeamMembershipsRequest();
        request.TeamId = teamId!;

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new ListTeamMembershipsRequest();
        request.TeamId = string.Empty; // Invalid TeamId

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new ListTeamMembershipsRequest();
        request.TeamId = string.Empty; // Invalid TeamId

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
