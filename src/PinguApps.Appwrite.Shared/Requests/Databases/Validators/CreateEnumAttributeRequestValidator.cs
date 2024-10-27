﻿using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateEnumAttributeRequestValidator : AbstractValidator<CreateEnumAttributeRequest>
{
    public CreateEnumAttributeRequestValidator()
    {
        Include(new CreateStringAttributeBaseRequestValidator<CreateEnumAttributeRequest, CreateEnumAttributeRequestValidator>());

        RuleFor(x => x.Elements)
            .NotNull()
            .WithMessage("Elements is required.")
            .Must(x => x.Count <= 100)
            .WithMessage("A maximum of 100 elements are allowed.")
            .ForEach(x =>
            {
                x
                    .NotEmpty()
                    .WithMessage("Element cannot be empty.")
                    .MaximumLength(255)
                    .WithMessage("Element cannot be longer than 255 characters");
            });

        RuleFor(x => x.Default)
            .Must((x, defaultValue) => defaultValue is null || x.Elements.Contains(defaultValue))
            .WithMessage("Default must either be null or match an existing element.");
    }
}
