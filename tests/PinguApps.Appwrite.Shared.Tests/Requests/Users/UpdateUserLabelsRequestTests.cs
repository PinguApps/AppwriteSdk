using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Requests.Users.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Users;
public class UpdateUserLabelsRequestTests : UserIdBaseRequestTests<UpdateUserLabelsRequest, UpdateUserLabelsRequestValidator>
{
    protected override UpdateUserLabelsRequest CreateValidRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateUserLabelsRequest();

        // Assert
        Assert.NotNull(request.Labels);
        Assert.Empty(request.Labels);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        var labels = new List<string> { "Label1", "Label2", "Label3" };

        // Arrange
        var request = new UpdateUserLabelsRequest();

        // Act
        request.Labels = labels;

        // Assert
        Assert.Collection(request.Labels,
            x => Assert.Equal(labels[0], x),
            x => Assert.Equal(labels[1], x),
            x => Assert.Equal(labels[2], x));
    }

    public static IEnumerable<object?[]> ValidLabelsData =>
        [
            [new List<string> { "Label1", "Label2", "Label3" }],
            [new List<string> { "A", "B", "C" }],
            [new List<string>()]
        ];

    [Theory]
    [MemberData(nameof(ValidLabelsData))]
    public void IsValid_WithValidData_ReturnsTrue(List<string> labels)
    {
        // Arrange
        var request = new UpdateUserLabelsRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Labels = labels
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static IEnumerable<object?[]> InvalidLabelsData =>
        [
            [new List<string> { "", "Label2", "Label3" }], // Invalid Label (empty string)
            [new List<string> { "Label1", "Label2", new string('a', 37) }], // Invalid Label (too long)
            [new List<string> { "Label1", "Label2", "Invalid@Label" }] // Invalid Label (non-alphanumeric)
        ];

    [Theory]
    [MemberData(nameof(InvalidLabelsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(List<string> labels)
    {
        // Arrange
        var request = new UpdateUserLabelsRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Labels = labels
        };

        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.False(isValid);
    }

    [Fact]
    public void Validate_WithThrowOnFailuresTrue_ThrowsValidationExceptionOnFailure()
    {
        // Arrange
        var request = new UpdateUserLabelsRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Labels = new List<string> { "", "@@@" }
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateUserLabelsRequest
        {
            UserId = IdUtils.GenerateUniqueId(),
            Labels = new List<string> { "", "@@@" }
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
