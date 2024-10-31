using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateIPAddressAttributeRequestTests : UpdateStringAttributeBaseRequestTests<UpdateIPAddressAttributeRequest, UpdateIPAddressAttributeRequestValidator>
{
    protected override UpdateIPAddressAttributeRequest CreateValidUpdateStringAttributeBaseRequest => new();

    protected override string ValidDefaultValue => "192.168.1.1";

    public static TheoryData<string> ValidDefaultValues =>
        [
            "192.0.2.1",
            "192.168.1.1",
            "2001:db8::1",
            "2001:db8:85a3::8a2e:370:7334",
            "::1",
            "fe80::1"
        ];

    [Theory]
    [MemberData(nameof(ValidDefaultValues))]
    public void IsValid_WithValidDefaults_ReturnsTrue(string defaultValue)
    {
        // Arrange
        var request = new UpdateIPAddressAttributeRequest
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
            "256.256.256.256",
            "192.168.1.1.1",
            "192.168.1.",
            ".192.168.1.1",
            "192.168.1.1/24",
            "192.168.1.x",
            "192.168.1.*",
            "abcd",
            "",
            "2001:db8::::1",
            "2001:db8",
            "2001:db8::/32",
            "2001:dg8::1"
        ];

    [Theory]
    [MemberData(nameof(InvalidDefaultValues))]
    public void IsValid_WithInvalidDefaults_ReturnsFalse(string defaultValue)
    {
        // Arrange
        var request = new UpdateIPAddressAttributeRequest
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
