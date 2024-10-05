using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class ListUserMembershipsRequestValidator : AbstractValidator<ListUserMembershipsRequest>
{
    public ListUserMembershipsRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<ListUserMembershipsRequest, ListUserMembershipsRequestValidator>());
    }
}
