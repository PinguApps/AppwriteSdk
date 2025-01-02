using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class DocumentsListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var documents = new List<Document>
        {
            new("5e5ea5c16897e", "5e5ea5c15117e", "5e5ea5c15117e",
                DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(),
                DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), [Permission.Read().Any()],
                [])
        };

        // Act
        var documentsList = new DocumentsList(total, documents);

        // Assert
        Assert.Equal(total, documentsList.Total);
        Assert.Equal(documents, documentsList.Documents);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var documentsList = JsonSerializer.Deserialize<DocumentsList>(TestConstants.DocumentsListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(documentsList);
        Assert.Equal(5, documentsList.Total);
        Assert.Single(documentsList.Documents);

        var document = documentsList.Documents[0];
        Assert.Equal("5e5ea5c16897e", document.Id);
        Assert.Equal("5e5ea5c15117e", document.CollectionId);
        Assert.Equal("5e5ea5c15117e", document.DatabaseId);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), document.CreatedAt?.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), document.UpdatedAt?.ToUniversalTime());
        Assert.NotNull(document.Permissions);
        Assert.Single(document.Permissions);
        Assert.Equal(PermissionType.Read, document.Permissions[0].PermissionType);
        Assert.Equal(RoleType.Any, document.Permissions[0].RoleType);
    }
}
