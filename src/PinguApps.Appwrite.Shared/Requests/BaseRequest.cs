using FluentValidation;
using FluentValidation.Results;
using PinguApps.Appwrite.Shared.Enums;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The base request - Provides core functionality to all requests
/// </summary>
/// <typeparam name="TRequest">The request type</typeparam>
/// <typeparam name="TValidator">The request validator type</typeparam>
public abstract class BaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    /// <summary>
    /// A flag to determine whether we are validating from the server or the client. Often not needed.
    /// </summary>
    public ValidationContext ValidationContext { get; set; } = ValidationContext.None;

    /// <summary>
    /// True if the request object passes all validation
    /// </summary>
    /// <returns>Whether the request object is valid</returns>
    public bool IsValid() => Validate().IsValid;

    /// <summary>
    /// Attempts to validate the request object
    /// </summary>
    /// <param name="throwOnFailures">If true, throws an exception on failure</param>
    /// <returns>The result, showing any errors if applicable</returns>
    public ValidationResult Validate(bool throwOnFailures = false)
    {
        var validator = new TValidator();

        if (throwOnFailures)
            return validator.Validate(this as TRequest, options => options.ThrowOnFailures());

        return validator.Validate((this as TRequest)!);
    }
}
