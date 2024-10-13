using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdateUserStatusRequestTests : UserIdBaseRequestTests<UpdateUserStatusRequest, UpdateUserStatusRequestValidator>
{
    protected override UpdateUserStatusRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateUserStatusRequest();

        // Assert
        Assert.False(request.Status);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = new UpdateUserStatusRequest();

        // Act
        request.Status = true;

        // Assert
        Assert.True(request.Status);
    }

    public static TheoryData<UpdateUserStatusRequest> ValidRequestsData = new()
        {
            new UpdateUserStatusRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Status = true
            },
            new UpdateUserStatusRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Status = false
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateUserStatusRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }
}
