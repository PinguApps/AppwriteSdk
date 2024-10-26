using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class ListCollectionsRequestTests : QuerySearchBaseRequestTests<ListCollectionsRequest, ListCollectionsRequestValidator>
{
    protected override ListCollectionsRequest CreateValidRequest => new()
    {
        DatabaseId = IdUtils.GenerateUniqueId()
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new ListCollectionsRequest();

        // Assert
        Assert.Equal(string.Empty, request.DatabaseId);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var databaseId = "testDatabaseId";

        var request = new ListCollectionsRequest();

        // Act
        request.DatabaseId = databaseId;

        // Assert
        Assert.Equal(databaseId, request.DatabaseId);
    }

    public static TheoryData<ListCollectionsRequest> ValidRequestsData = new()
        {
            new()
            {
                DatabaseId = "validDatabaseId123"
            },
            new()
            {
                DatabaseId = "anotherValidDatabaseId"
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(ListCollectionsRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<ListCollectionsRequest> InvalidRequestsData = new()
        {
            new()
            {
                DatabaseId = null!
            },
            new()
            {
                DatabaseId = ""
            }
        };

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(ListCollectionsRequest request)
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
        var request = new ListCollectionsRequest
        {
            DatabaseId = ""
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new ListCollectionsRequest
        {
            DatabaseId = ""
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
