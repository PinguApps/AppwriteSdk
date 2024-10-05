using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class ListUserTargetsRequestValidator : AbstractValidator<ListUserTargetsRequest>
{
    public ListUserTargetsRequestValidator()
    {
        Include(new UserIdBaseRequestValidator<ListUserTargetsRequest, ListUserTargetsRequestValidator>());

        RuleFor(x => x.Queries)
            .Must(queries => queries is null || queries.Count <= 100)
            .WithMessage("A maximum of 100 queries are allowed.")
            .ForEach(queryRule => queryRule
                .Must(query => query.GetQueryString().Length <= 4096)
                .WithMessage("Each query must be at most 4096 characters long.")
                .Must(x => x.Attribute is null ||
                     x.Attribute == "name" ||
                     x.Attribute == "email" ||
                     x.Attribute == "phone" ||
                     x.Attribute == "status" ||
                     x.Attribute == "passwordUpdate" ||
                     x.Attribute == "registration" ||
                     x.Attribute == "emailVerification" ||
                     x.Attribute == "phoneVerification" ||
                     x.Attribute == "labels")
                .WithMessage("Only supported query attributes are name, email, phone, status, passwordUpdate, registration, emailVerification, phoneVerification, labels.")
            );
    }
}
