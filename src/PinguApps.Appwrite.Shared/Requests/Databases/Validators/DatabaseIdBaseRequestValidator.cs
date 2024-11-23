using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class DatabaseIdBaseRequestValidator<TRequest, TValidator> : AbstractValidator<DatabaseIdBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public DatabaseIdBaseRequestValidator()
    {
        RuleFor(x => x.DatabaseId)
            .NotEmpty()
            .WithMessage("DatabaseId is required.");
    }
}
