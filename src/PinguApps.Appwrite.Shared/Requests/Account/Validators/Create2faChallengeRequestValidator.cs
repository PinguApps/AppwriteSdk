﻿using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Account.Validators;

/// <summary>
/// Validator for <see cref="Create2faChallengeRequest"/>
/// </summary>
public class Create2faChallengeRequestValidator : AbstractValidator<Create2faChallengeRequest>
{
    public Create2faChallengeRequestValidator()
    {
        RuleFor(x => x.Factor)
            .IsInEnum().WithMessage("Factor must be one of the predefined values: email, phone, totp, or recoveryCode.");
    }
}
