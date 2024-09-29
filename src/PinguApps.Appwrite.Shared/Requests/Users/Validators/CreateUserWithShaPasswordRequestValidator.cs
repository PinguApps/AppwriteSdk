using System;
using System.Linq;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Users.Validators;
public class CreateUserWithShaPasswordRequestValidator : AbstractValidator<CreateUserWithShaPasswordRequest>
{
    private static readonly string[] AllowedPasswordVersions =
    {
        "sha1", "sha224", "sha256", "sha384", "sha512/224", "sha512/256", "sha512", "sha3-224", "sha3-256", "sha3-384", "sha3-512"
    };

    public CreateUserWithShaPasswordRequestValidator()
    {
        Include(new CreateUserWithPasswordBaseRequestValidator<CreateUserWithShaPasswordRequest, CreateUserWithShaPasswordRequestValidator>());

        RuleFor(x => x.PasswordVersion)
            .Must(BeAValidPasswordVersion)
            .WithMessage("Invalid password version.");
    }

    private bool BeAValidPasswordVersion(string? passwordVersion)
    {
        return string.IsNullOrEmpty(passwordVersion) || AllowedPasswordVersions.Contains(passwordVersion);
    }
}
