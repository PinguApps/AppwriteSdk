using FluentValidation;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Requests.Teams.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Teams;
public class CreateTeamMembershipRequestTests : TeamIdBaseRequestTests<CreateTeamMembershipRequest, CreateTeamMembershipRequestValidator>
{
    protected override CreateTeamMembershipRequest CreateValidRequest => new()
    {
        UserId = IdUtils.GenerateUniqueId()
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateTeamMembershipRequest();

        // Assert
        Assert.Empty(request.Roles);
        Assert.Null(request.Email);
        Assert.Null(request.UserId);
        Assert.Null(request.Phone);
        Assert.Null(request.Url);
        Assert.Null(request.Name);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var roles = new List<string> { "admin", "member" };
        var email = "pingu@example.com";
        var userId = IdUtils.GenerateUniqueId();
        var phone = "+123456789";
        var url = "https://example.com";
        var name = "Pingu";

        var request = new CreateTeamMembershipRequest();

        // Act
        request.Roles = roles;
        request.Email = email;
        request.UserId = userId;
        request.Phone = phone;
        request.Url = url;
        request.Name = name;

        // Assert
        Assert.Equal(roles, request.Roles);
        Assert.Equal(email, request.Email);
        Assert.Equal(userId, request.UserId);
        Assert.Equal(phone, request.Phone);
        Assert.Equal(url, request.Url);
        Assert.Equal(name, request.Name);
    }

    public static TheoryData<CreateTeamMembershipRequest> ValidRequestsData =>
    [
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Roles = ["admin", "member"],
            Email = "pingu@example.com",
            UserId = IdUtils.GenerateUniqueId(),
            Phone = "+123456789",
            Url = "https://example.com",
            Name = "Test User"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            ValidationContext = ValidationContext.Server
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Url = "https://example.com",
            ValidationContext = ValidationContext.Client
        }
    ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(CreateTeamMembershipRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateTeamMembershipRequest> InvalidRequestsData = new()
    {
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Roles = [new string('a', 33)],
            UserId = IdUtils.GenerateUniqueId()
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Roles = new List<string>(new string[101]),
            UserId = IdUtils.GenerateUniqueId()
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Email = ""
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Email = "invalid-email"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Phone = ""
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            Phone = "123456789"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Url = ""
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Url = "invalid-url"
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Name = ""
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            Name = new string('a', 129)
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId()
        },
        new()
        {
            TeamId = IdUtils.GenerateUniqueId(),
            UserId = IdUtils.GenerateUniqueId(),
            ValidationContext = ValidationContext.Client
        }
    };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreateTeamMembershipRequest request)
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
        var request = new CreateTeamMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId()
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateTeamMembershipRequest
        {
            TeamId = IdUtils.GenerateUniqueId()
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
