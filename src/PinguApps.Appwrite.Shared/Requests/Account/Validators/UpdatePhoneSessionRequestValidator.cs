﻿using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="UpdatePhoneSessionRequest"/>
/// </summary>
public class UpdatePhoneSessionRequestValidator : AbstractValidator<UpdatePhoneSessionRequest>
{
    public UpdatePhoneSessionRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("The user ID is required.")
            .Matches("^[a-zA-Z0-9][a-zA-Z0-9._-]{0,35}$").WithMessage("The user ID must be between 1 and 36 characters long and can only contain a-z, A-Z, 0-9, period, hyphen, and underscore.");

        RuleFor(x => x.Secret)
            .NotEmpty().WithMessage("The secret is required.");
    }
}
