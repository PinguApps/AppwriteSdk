using System.Net;
using System.Net.Sockets;
using FluentValidation;

namespace PinguApps.Appwrite.Shared.Requests.Databases.Validators;
public class CreateIPAttributeRequestValidator : AbstractValidator<CreateIPAttributeRequest>
{
    public CreateIPAttributeRequestValidator()
    {
        Include(new CreateStringAttributeBaseRequestValidator<CreateIPAttributeRequest, CreateIPAttributeRequestValidator>());

        RuleFor(x => x.Default)
            .NotEmpty()
            .When(x => x.Default is not null, ApplyConditionTo.CurrentValidator)
            .WithMessage("Default must not be an empty string.")
            .Must(BeValidIpAddress)
            .WithMessage("Default is not a valid IP Address format.");
    }

    private bool BeValidIpAddress(string? ipAddress)
    {
        if (string.IsNullOrEmpty(ipAddress))
            return true;

        // Try parsing as IP address (supports both IPv4 and IPv6)
        if (IPAddress.TryParse(ipAddress, out var parsedIp))
        {
            // Accept both IPv4 and IPv6
            return parsedIp.AddressFamily == AddressFamily.InterNetwork ||
                   parsedIp.AddressFamily == AddressFamily.InterNetworkV6;
        }

        return false;
    }
}
