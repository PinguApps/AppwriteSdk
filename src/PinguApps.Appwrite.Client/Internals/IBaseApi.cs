using PinguApps.Appwrite.Shared;
using Refit;

namespace PinguApps.Appwrite.Client.Internals;

[Headers("Content-Type: application/json",
    "X-Sdk-Name: .NET",
    "X-Sdk-Platform: client",
    "X-Sdk-Language: dotnet",
    $"X-Sdk-Version: {Constants.Version}",
    "X-Appwrite-Response-Format: 1.6.0")]
internal interface IBaseApi
{
}
