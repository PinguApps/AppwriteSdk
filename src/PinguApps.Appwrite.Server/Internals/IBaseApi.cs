using PinguApps.Appwrite.Shared;
using Refit;

namespace PinguApps.Appwrite.Server.Internals;

[Headers("content-type: application/json",
    "x-sdk-name: .NET",
    "x-sdk-platform: server",
    "x-sdk-language: dotnet",
    $"x-sdk-version: {Constants.Version}",
    "X-Appwrite-Response-Format: 1.6.0")]
internal interface IBaseApi
{
}
