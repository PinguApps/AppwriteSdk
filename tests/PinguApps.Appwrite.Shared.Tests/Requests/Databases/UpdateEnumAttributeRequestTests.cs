using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateEnumAttributeRequestTests : UpdateStringAttributeBaseRequestTests<UpdateEnumAttributeRequest, UpdateEnumAttributeRequestValidator>
{
    protected override UpdateEnumAttributeRequest CreateValidUpdateStringAttributeBaseRequest => new()
    {
        Elements = ["element1", "element2", "element3"]
    };

    protected override string ValidDefaultValue => "element2";

    public static TheoryData<string?> ValidDefaultValues =>
        [
            "element1",
            "element2",
            "element3",
            null
        ];

    [Theory]
    [MemberData(nameof(ValidDefaultValues))]
    public void IsValid_WithValidDefaults_ReturnsTrue(string? value)
    {
        // Arrange
        var request = new UpdateEnumAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Elements = ["element1", "element2", "element3"],
            Default = value
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<string> InvalidDefaultValues =>
        [
            "element4",
            "",
            "not an existing element at all"
        ];

    [Theory]
    [MemberData(nameof(InvalidDefaultValues))]
    public void IsValid_WithInvalidDefaults_ReturnsTrue(string value)
    {
        // Arrange
        var request = new UpdateEnumAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Elements = ["element1", "element2", "element3"],
            Default = value
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    public static TheoryData<List<string>> InvalidElementsValues =>
        [
            [],
            [new string('a', 256)],
            Enumerable.Range(0,101).Select(x => x.ToString()).ToList(),
            [""]
        ];

    [Theory]
    [MemberData(nameof(InvalidElementsValues))]
    public static void IsValid_WithInvalidElements_ReturnsFalse(List<string> elements)
    {
        // Arrange
        var request = new UpdateEnumAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Elements = elements
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }
}
