using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class QueryBaseRequestValidator<TRequest, TValidator> : AbstractValidator<QueryBaseRequest<TRequest, TValidator>>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public QueryBaseRequestValidator()
    {
        RuleFor(x => x.Queries)
            .Must(queries => queries is null || queries.Count <= 100).WithMessage("A maximum of 100 queries are allowed.")
            .ForEach(query => query.Must(q => q.GetQueryString().Length <= 4096).WithMessage("Each query can be a maximum of 4096 characters long."));
    }
}
