using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class CreateStringAttributeRequestTests : CreateStringAttributeBaseRequestTests<CreateStringAttributeRequest, CreateStringAttributeRequestValidator>
{
    protected override CreateStringAttributeRequest CreateValidCreateStringAttributeBaseRequest => new()
    {
        Size = 100
    };

    protected override string ValidDefaultValue => "A valid string";

    public static TheoryData<CreateStringAttributeRequest> ValidRequests =>
    [
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = null,
            Size = 1,
            Encrypt = false
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = new string('1', 10),
            Size = 10,
            Encrypt = true
        }
    ];

    [Theory]
    [MemberData(nameof(ValidRequests))]
    public void IsValid_WithValidRequest_ReturnsTrue(CreateStringAttributeRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateStringAttributeRequest> InvalidRequests =>
    [
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = null,
            Size = 0,
            Encrypt = false
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = null,
            Size = 1_073_741_825,
            Encrypt = false
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = new string('a', 11),
            Size = 10,
            Encrypt = false
        }
    ];

    [Theory]
    [MemberData(nameof(InvalidRequests))]
    public void IsValid_WithInvalidRequest_ReturnsFalse(CreateStringAttributeRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }
}
