using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdatePhoneVerificationRequestTests : UserIdBaseRequestTests<UpdatePhoneVerificationRequest, UpdatePhoneVerificationRequestValidator>
{
    protected override UpdatePhoneVerificationRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdatePhoneVerificationRequest();

        // Assert
        Assert.False(request.PhoneVerification);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var request = new UpdatePhoneVerificationRequest();

        // Act
        request.PhoneVerification = true;

        // Assert
        Assert.NotNull(request.UserId);
        Assert.True(request.PhoneVerification);
    }

    public static TheoryData<UpdatePhoneVerificationRequest> ValidRequestsData = new()
        {
            new UpdatePhoneVerificationRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                PhoneVerification = true
            },
            new UpdatePhoneVerificationRequest
            {
                UserId = IdUtils.GenerateUniqueId(),
                PhoneVerification = false
            }
        };

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdatePhoneVerificationRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }
}
