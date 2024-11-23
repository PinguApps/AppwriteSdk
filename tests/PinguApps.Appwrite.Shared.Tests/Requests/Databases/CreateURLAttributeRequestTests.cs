using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class CreateURLAttributeRequestTests : CreateStringAttributeBaseRequestTests<CreateURLAttributeRequest, CreateURLAttributeRequestValidator>
{
    protected override CreateURLAttributeRequest CreateValidCreateStringAttributeBaseRequest => new();

    protected override string ValidDefaultValue => "https://example.com";

    public static TheoryData<string> ValidDefaultValues =>
    [
        "https://example.com",
        "https://www.example.com",
        "http://example.com",
        "https://example.com/path/to/resource.html",
        "https://example.com/path/to/resource",
        "https://example.com/path-with-hyphens",
        "https://example.com/path_with_underscores",
        "https://example.com?key=value",
        "https://example.com/?key=value",
        "https://example.com/path?key1=value1&key2=value2",
        "https://example.com/path?key=value%20with%20encoded%20spaces",
        "https://localhost:1234",
        "http://127.0.0.1:8080",
        "https://example.com:8080/path",
        "https://user:pass@example.com",
        "https://user:pass@example.com:8080/path?query=value",
        "https://example.com/path?search=R%26D",
        "https://example.com/path?currency=%24100",
        "https://example.com/path(1)/resource",
        "https://example.com/path?name=John+Doe",
        "https://example.com#section",
        "https://example.com/#section",
        "https://example.com/path#section",
        "https://example.com/path?query=value#section"
    ];

    [Theory]
    [MemberData(nameof(ValidDefaultValues))]
    public void IsValid_WithValidDefaults_ReturnsTrue(string defaultValue)
    {
        // Arrange
        var request = new CreateURLAttributeRequest
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
        "example.com",
        "www.example.com",
        "https:/example.com",
        "https//example.com",
        "https://exam ple.com",
    ];

    [Theory]
    [MemberData(nameof(InvalidDefaultValues))]
    public void IsValid_WithInvalidDefaults_ReturnsFalse(string defaultValue)
    {
        // Arrange
        var request = new CreateURLAttributeRequest
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
