using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateStringAttributeRequestTests : UpdateStringAttributeBaseRequestTests<UpdateStringAttributeRequest, UpdateStringAttributeRequestValidator>
{
    protected override UpdateStringAttributeRequest CreateValidUpdateStringAttributeBaseRequest => new();

    protected override string ValidDefaultValue => "Valid Value";

    public static TheoryData<UpdateStringAttributeRequest> ValidRequests =>
    [
        new UpdateStringAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Size = 10,
            Default = "Valid"
        },
        new UpdateStringAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Size = 1_073_741_824,
            Default = "Valid Value"
        },
        new UpdateStringAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Size = 1_073_741_824,
            Default = null
        },
        new UpdateStringAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Size = null,
            Default = "Valid"
        },
        new UpdateStringAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Size = null,
            Default = null
        }
    ];

    [Theory]
    [MemberData(nameof(ValidRequests))]
    public void IsValid_WithValidRequest_ReturnsTrue(UpdateStringAttributeRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateStringAttributeRequest> InvalidRequests =>
    [
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = null,
            Size = 0
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = null,
            Size = 1_073_741_825
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Default = new string('a', 11),
            Size = 10
        }
    ];

    [Theory]
    [MemberData(nameof(InvalidRequests))]
    public void IsValid_WithInvalidRequest_ReturnsFalse(UpdateStringAttributeRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }
}
