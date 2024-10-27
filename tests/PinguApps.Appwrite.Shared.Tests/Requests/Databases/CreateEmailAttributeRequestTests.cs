using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class CreateEmailAttributeRequestTests : CreateStringAttributeBaseRequestTests<CreateEmailAttributeRequest, CreateEmailAttributeRequestValidator>
{
    protected override CreateEmailAttributeRequest CreateValidCreateStringAttributeBaseRequest => new();

    public static TheoryData<string> ValidDefaultValues =>
        [
            "pingu@example.com",
            "ugnip@mydomain.co.uk"
        ];

    [Theory]
    [MemberData(nameof(ValidDefaultValues))]
    public void IsValid_WithValidDefaults_ReturnsTrue(string defaultValue)
    {
        // Arrange
        var request = new CreateEmailAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = defaultValue
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<string> InvalidDefaultValues =>
        [
            "not an email address",
            "something at something else dot com",
            "@!.d"
        ];

    [Theory]
    [MemberData(nameof(InvalidDefaultValues))]
    public void IsValid_WithInvalidDefaults_ReturnsFalse(string defaultValue)
    {
        // Arrange
        var request = new CreateEmailAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = defaultValue
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }
}
