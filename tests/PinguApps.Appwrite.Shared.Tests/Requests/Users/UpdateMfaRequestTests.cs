using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdateMfaRequestTests : UserIdBaseRequestTests<UpdateMfaRequest, UpdateMfaRequestValidator>
{
    protected override UpdateMfaRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateMfaRequest();

        // Assert
        Assert.False(request.Mfa);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var mfa = true;

        // Arrange
        var request = new UpdateMfaRequest();

        // Act
        request.Mfa = mfa;

        // Assert
        Assert.Equal(mfa, request.Mfa);
    }

    public static TheoryData<UpdateMfaRequest> ValidRequestsData = new()
        {
            new UpdateMfaRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Mfa = true
            },
            new UpdateMfaRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                Mfa = false
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateMfaRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }
}
