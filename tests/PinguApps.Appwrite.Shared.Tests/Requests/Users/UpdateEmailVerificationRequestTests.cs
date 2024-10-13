using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdateEmailVerificationRequestTests : UserIdBaseRequestTests<UpdateEmailVerificationRequest, UpdateEmailVerificationRequestValidator>
{
    protected override UpdateEmailVerificationRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateEmailVerificationRequest();

        // Assert
        Assert.False(request.EmailVerification);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = new UpdateEmailVerificationRequest();

        // Act
        request.EmailVerification = true;

        // Assert
        Assert.True(request.EmailVerification);
    }

    public static TheoryData<UpdateEmailVerificationRequest> ValidRequestsData = new()
        {
            new UpdateEmailVerificationRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                EmailVerification = true
            },
            new UpdateEmailVerificationRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                EmailVerification = false
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateEmailVerificationRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }
}
