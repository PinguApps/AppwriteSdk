using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class ListUserTargetsRequestTests : UserIdBaseRequestTests<ListUserTargetsRequest, ListUserTargetsRequestValidator>
{
    protected override ListUserTargetsRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new ListUserTargetsRequest();

        // Assert
        Assert.Null(request.Queries);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var queries = new List<Query>
            {
                Query.Equal("name", "John")
            };
        var request = new ListUserTargetsRequest();

        // Act
        request.Queries = queries;

        // Assert
        Assert.Equal(queries, request.Queries);
    }

    public static TheoryData<ListUserTargetsRequest> ValidRequestsData = new()
        {
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries = null
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.And(
                        [
                            Query.Equal("name", "Pingu"),
                            Query.Contains("email", "example.com")
                        ])
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Between("name", "p", "pz")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Contains("name", "Pin")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.CursorAfter(IdUtils.GenerateUniqueId())
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.CursorBefore(IdUtils.GenerateUniqueId())
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.EndsWith("name", "gu")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("name", "Pingu")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.GreaterThan("name", "Pin")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.GreaterThanEqual("name", "Pin")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.IsNotNull("name")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.IsNull("name")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.LessThan("name", "Pim")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.LessThanEqual("name", "Pim")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Limit(10)
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.NotEqual("name", "ugniP")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Offset(10)
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Or(
                        [
                            Query.Equal("name", "Pingu"),
                            Query.Contains("email", "example.com")
                        ])
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.OrderAsc("name")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.OrderDesc("name")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Search("name", "pin")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Select(["name"])
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.StartsWith("name", "pin")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("email", "pingu@example.com")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("phone", "+44123456789")
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("status", true)
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("passwordUpdate", true)
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("registration", true)
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("emailVerification", true)
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("phoneVerification", true)
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("labels", "Admin")
                ]
            },
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(ListUserTargetsRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<ListUserTargetsRequest> InvalidRequestsData = new()
        {
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries = Enumerable.Range(0, 101).Select(x => Query.Offset(x)).ToList()
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("name", new string('a', 4097))
                ]
            },
            new ListUserTargetsRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Queries =
                [
                    Query.Equal("NotAValidAttribute", "Pingu")
                ]
            },
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(ListUserTargetsRequest request)
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
        var request = new ListUserTargetsRequest
        {
            UserId = string.Empty,
            Queries =
            [
                Query.Equal("name", new string('a', 4097))
            ]
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new ListUserTargetsRequest
        {
            UserId = string.Empty,
            Queries =
            [
                Query.Equal("name", new string('a', 4097))
            ]
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
