using FluentValidation;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class CreateRelationshipAttributeRequestTests : DatabaseCollectionIdBaseRequestTests<CreateRelationshipAttributeRequest, CreateRelationshipAttributeRequestValidator>
{
    protected override CreateRelationshipAttributeRequest CreateValidDatabaseCollectionIdRequest => new()
    {
        RelatedCollectionId = IdUtils.GenerateUniqueId(),
        Key = "validKey"
    };

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateRelationshipAttributeRequest();

        // Assert
        Assert.Equal(string.Empty, request.RelatedCollectionId);
        Assert.Equal(RelationType.OneToOne, request.Type);
        Assert.False(request.TwoWay);
        Assert.Equal(string.Empty, request.Key);
        Assert.NotEmpty(request.TwoWayKey);
        Assert.Equal(OnDelete.Restrict, request.OnDelete);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var relatedCollectionId = IdUtils.GenerateUniqueId();
        var type = RelationType.ManyToMany;
        var twoWay = true;
        var key = "validKey";
        var twoWayKey = "validTwoWayKey";
        var onDelete = OnDelete.Cascade;
        var request = new CreateRelationshipAttributeRequest();

        // Act
        request.RelatedCollectionId = relatedCollectionId;
        request.Type = type;
        request.TwoWay = twoWay;
        request.Key = key;
        request.TwoWayKey = twoWayKey;
        request.OnDelete = onDelete;

        // Assert
        Assert.Equal(relatedCollectionId, request.RelatedCollectionId);
        Assert.Equal(type, request.Type);
        Assert.Equal(twoWay, request.TwoWay);
        Assert.Equal(key, request.Key);
        Assert.Equal(twoWayKey, request.TwoWayKey);
        Assert.Equal(onDelete, request.OnDelete);
    }

    [Fact]
    public void IsValid_WithValidData_ReturnsTrue()
    {
        // Arrange
        var request = new CreateRelationshipAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey"
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<CreateRelationshipAttributeRequest> InvalidRequests =>
    [
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = null!,
            Key = "validKey"
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = "",
            Key = "validKey"
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = IdUtils.GenerateUniqueId(),
            Key = null!
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = IdUtils.GenerateUniqueId(),
            Key = ""
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            Type = (RelationType) 999
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            TwoWayKey = null!
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            TwoWayKey = ""
        },
        new()
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = IdUtils.GenerateUniqueId(),
            Key = "validKey",
            OnDelete = (OnDelete) 999
        }
    ];

    [Theory]
    [MemberData(nameof(InvalidRequests))]
    public void IsValid_WithInvalidData_ReturnsFalse(CreateRelationshipAttributeRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new CreateRelationshipAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = IdUtils.GenerateUniqueId(),
            Key = "",
            Type = (RelationType)999,
            TwoWayKey = "",
            OnDelete = (OnDelete)999
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new CreateRelationshipAttributeRequest
        {
            DatabaseId = IdUtils.GenerateUniqueId(),
            CollectionId = IdUtils.GenerateUniqueId(),
            RelatedCollectionId = IdUtils.GenerateUniqueId(),
            Key = "",
            Type = (RelationType)999,
            TwoWayKey = "",
            OnDelete = (OnDelete)999
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
