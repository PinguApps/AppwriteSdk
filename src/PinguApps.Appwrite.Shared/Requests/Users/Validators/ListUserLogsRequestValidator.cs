using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class ListUserLogsRequestValidator : AbstractValidator<ListUserLogsRequest>
{
    public ListUserLogsRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<ListUserLogsRequest, ListUserLogsRequestValidator>());

        RuleFor(x => x.Queries)
            .Must(queries => queries is null || queries.Count <= 100)
            .WithMessage("A maximum of 100 queries are allowed.")
            .ForEach(queryRule => queryRule
                .Must(query => query.GetQueryString().Length <= 4096)
                .WithMessage("Each query must be at most 4096 characters long.")
                .Must(x => x.Method == "limit" || x.Method == "offset")
                .WithMessage("Only supported query methods are limit and offset")
            );
    }
}
