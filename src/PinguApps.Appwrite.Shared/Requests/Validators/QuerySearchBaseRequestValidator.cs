using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class QuerySearchBaseRequestValidator<TRequest, TValidator> : AbstractValidator<QuerySearchBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public QuerySearchBaseRequestValidator()
    {
        Include(new QuerySearchBaseRequestValidator<TRequest, TValidator>());

        RuleFor(request => request.Search)
            .MaximumLength(256)
            .WithMessage("Search term must not exceed 256 characters.");
    }
}
