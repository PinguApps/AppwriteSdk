using FluentValidation;
using PinguApps.Appwrite.Shared.Requests.Validators;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;
public class ListLogsRequestValidator : AbstractValidator<ListLogsRequest>
{
    public ListLogsRequestValidator()
    {
        Include(new QueryBaseRequestValidator<ListLogsRequest, ListLogsRequestValidator>());
    }
}
