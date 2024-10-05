using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class GetUserPreferencesRequestValidator : AbstractValidator<GetUserPreferencesRequest>
{
    public GetUserPreferencesRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<GetUserPreferencesRequest, GetUserPreferencesRequestValidator>());
    }
}
