using FluentValidation;
using FluentValidation.Results;

namespace PinguApps.Appwrite.Shared.Requests;
public abstract class BaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public bool IsValid() => Validate().IsValid;

    public ValidationResult Validate(bool throwOnFailures = false)
    {
        var validator = new TValidator();

        if (throwOnFailures)
            return validator.Validate(this as TRequest, options => options.ThrowOnFailures());

        return validator.Validate((this as TRequest)!);
    }
}
