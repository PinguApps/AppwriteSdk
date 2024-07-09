using System.Text.Json.Serialization;
using FluentValidation;
using FluentValidation.Results;

namespace PinguApps.Appwrite.Shared.Requests;

/// <summary>
/// The request for updating a users phone
/// </summary>
public class UpdatePhoneRequest : IRequestValidator
{
    /// <summary>
    /// Phone number. Format this number with a leading '+' and a country code, e.g., +16175551212
    /// </summary>
    [JsonPropertyName("phone")]
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// New user password. Must be at least 8 chars
    /// </summary>
    [JsonPropertyName("password")]
    public string Password { get; set; } = string.Empty;

    /// <inheritdoc/>
    public bool IsValid() => Validate().IsValid;

    /// <inheritdoc/>
    public ValidationResult Validate(bool throwOnFailures = false)
    {
        var validator = new UpdatePhoneRequestValidator();

        if (throwOnFailures)
            return validator.Validate(this, x => x.ThrowOnFailures());

        return validator.Validate(this);
    }
}

internal class UpdatePhoneRequestValidator : AbstractValidator<UpdatePhoneRequest>
{
    public UpdatePhoneRequestValidator()
    {
        RuleFor(x => x.Phone).NotEmpty().Matches("^\\+\\d*$");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }
}
