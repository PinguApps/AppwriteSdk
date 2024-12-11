using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class GetDatabaseRequestValidator : AbstractValidator<GetDatabaseRequest>
{
    public GetDatabaseRequestValidator()
    {
        Include(new DatabaseIdBaseRequestValidator<GetDatabaseRequest, GetDatabaseRequestValidator>());
    }
}
