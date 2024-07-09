using FluentValidation.Results;

namespace PinguApps.Appwrite.Shared.Requests;
public interface IRequestValidator
{
    /// <summary>
    /// Checks if the data within the request is valid
    /// </summary>
    /// <returns>true if the request is valid</returns>
    public bool IsValid();

    /// <summary>
    /// Checks if the data within the request is valid, and returns errors if any are found
    /// </summary>
    /// <param name="throwOnFailures">If true, then will throw an exception if any errors are found. False by default</param>
    /// <returns>ValidationResult, containing bool indicating validity and any errors found</returns>
    public ValidationResult Validate(bool throwOnFailures = false);
}
