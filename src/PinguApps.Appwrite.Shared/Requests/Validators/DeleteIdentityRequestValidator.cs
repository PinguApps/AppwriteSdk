﻿using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Validators;
public class DeleteIdentityRequestValidator : AbstractValidator<DeleteIdentityRequest>
{
    public DeleteIdentityRequestValidator()
    {
        RuleFor(request => request.IdentityId)
            .NotEmpty().WithMessage("Identity ID must not be empty.");
    }
}