﻿using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class ListIndexesRequestValidator : AbstractValidator<ListIndexesRequest>
{
    public ListIndexesRequestValidator()
    {
        Include(new DatabaseCollectionIdBaseRequestValidator<ListIndexesRequest, ListIndexesRequestValidator>());

        RuleFor(x => x.Queries)
            .Must(queries => queries is null || queries.Count <= 100)
            .WithMessage("A maximum of 100 queries are allowed.")
            .ForEach(query => query.Must(q => q.GetQueryString().Length <= 4096)
            .WithMessage("Each query can be a maximum of 4096 characters long."));
    }
}
