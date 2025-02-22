﻿using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Requests.Databases.Validators;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Tests.Requests.Databases;
public class UpdateDatetimeAttributeRequestTests : UpdateAttributeBaseRequestTests<UpdateDatetimeAttributeRequest, UpdateDatetimeAttributeRequestValidator>
{
    protected override UpdateDatetimeAttributeRequest CreateValidUpdateAttributeBaseRequest => new();

    [Fact]
    public void Constructor_InitializesWithExpectedValues()
    {
        // Arrange & Act
        var request = new UpdateDatetimeAttributeRequest();

        // Assert
        Assert.Null(request.Default);
    }

    [Fact]
    public void Properties_CanBeSet()
    {
        // Arrange
        var defaultValue = DateTime.UtcNow;

        var request = new UpdateDatetimeAttributeRequest();

        // Act
        request.Default = defaultValue;

        // Assert
        Assert.Equal(defaultValue, request.Default);
    }

    public static TheoryData<UpdateDatetimeAttributeRequest> ValidRequestsData =>
        [
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = null,
                Required = true
            },
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = DateTime.UtcNow,
                Required = false
            }
        ];

    [Theory]
    [MemberData(nameof(ValidRequestsData))]
    public void IsValid_WithValidData_ReturnsTrue(UpdateDatetimeAttributeRequest request)
    {
        // Act
        var isValid = request.IsValid();

        // Assert
        Assert.True(isValid);
    }

    public static TheoryData<UpdateDatetimeAttributeRequest> InvalidRequestsData =>
        [
            new()
            {
                DatabaseId = IdUtils.GenerateUniqueId(),
                CollectionId = IdUtils.GenerateUniqueId(),
                Key = IdUtils.GenerateUniqueId(),
                Default = DateTime.UtcNow,
                Required = true
            }
        ];

    [Theory]
    [MemberData(nameof(InvalidRequestsData))]
    public void IsValid_WithInvalidData_ReturnsFalse(UpdateDatetimeAttributeRequest request)
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
        var request = new UpdateDatetimeAttributeRequest
        {
            Default = DateTime.UtcNow,
            Required = true
        };

        // Assert
        Assert.Throws<ValidationException>(() => request.Validate(true));
    }

    [Fact]
    public void Validate_WithThrowOnFailuresFalse_ReturnsInvalidResultOnFailure()
    {
        // Arrange
        var request = new UpdateDatetimeAttributeRequest
        {
            Default = DateTime.UtcNow,
            Required = true
        };

        // Act
        var result = request.Validate(false);

        // Assert
        Assert.False(result.IsValid);
    }
}
