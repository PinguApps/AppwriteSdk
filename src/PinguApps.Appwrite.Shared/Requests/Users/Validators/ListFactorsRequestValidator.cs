using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class ListFactorsRequestValidator : AbstractValidator<ListFactorsRequest>
{
    public ListFactorsRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<ListFactorsRequest, ListFactorsRequestValidator>());
    }
}
