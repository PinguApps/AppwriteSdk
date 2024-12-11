using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class DeleteDatabaseRequestValidator : AbstractValidator<DeleteDatabaseRequest>
{
    public DeleteDatabaseRequestValidator()
    {
        Include(new DatabaseIdBaseRequestValidator<DeleteDatabaseRequest, DeleteDatabaseRequestValidator>());
    }
}
