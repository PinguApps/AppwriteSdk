using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class NonGenericCreateDocumentRequestTests : DatabaseCollectionIdBaseRequestTests<CreateDocumentRequest<Dictionary<string, object?>>, CreateDocumentRequestValidator<Dictionary<string, object?>>>
{
    protected override CreateDocumentRequest<Dictionary<string, object?>> CreateValidDatabaseCollectionIdRequest => CreateDocumentRequest
        .CreateBuilder()
        .WithDocumentId(IdUtils.GenerateUniqueId())
        .AddField("name", "Pingu")
        .Build();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new CreateDocumentRequest();

        // Assert
        Assert.NotEmpty(request.DocumentId);
        Assert.Null(request.Data);
        Assert.Null(request.Permissions);
    }

    [Theory]
    [InlineData("string", "value")]
    [InlineData("number", 42)]
    [InlineData("boolean", true)]
    [InlineData("null", null)]
    public void Data_CanStoreVariousTypes(string key, object? value)
    {
        // Arrange
        var request = new CreateDocumentRequest();
        request.Data = [];

        // Act
        request.Data[key] = value;

        // Assert
        Assert.Equal(value, request.Data[key]);
    }

    [Fact]
    public void CreateBuilder_ReturnsNewBuilder()
    {
        // Act
        var builder = CreateDocumentRequest.CreateBuilder();

        // Assert
        Assert.NotNull(builder);
        Assert.IsAssignableFrom<ICreateDocumentRequestBuilder>(builder);
    }
}
