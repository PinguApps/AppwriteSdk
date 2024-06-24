using System;
using System.Text.Json;
using PinguApps.Appwrite.Shared;
using Refit;

namespace PinguApps.Appwrite.Client.Utils;
internal static class ResponseUtils
{
    internal static AppwriteResult<T> GetApiResponse<T>(this IApiResponse<T> result)
    {
        if (result.IsSuccessStatusCode)
        {
            if (result.Content is null)
            {
                return new AppwriteResult<T>(new InternalError("Response content was null"));
            }

            return new AppwriteResult<T>(result.Content);
        }

        if (result.Error?.Content is null)
        {
            throw new Exception("Unknown error encountered.");
        }

        var error = JsonSerializer.Deserialize<AppwriteError>(result.Error.Content);

        return new AppwriteResult<T>(error!);
    }

    internal static AppwriteResult<T> GetExceptionResponse<T>(this Exception e)
    {
        return new AppwriteResult<T>(new InternalError(e.Message));
    }
}
