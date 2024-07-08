using OneOf;

namespace PinguApps.Appwrite.Shared;

/// <summary>
/// The result of all API calls
/// </summary>
/// <typeparam name="TResult">the type of response expected on success</typeparam>
public class AppwriteResult<TResult>
{
    public AppwriteResult(OneOf<TResult, AppwriteError, InternalError> result)
    {
        Result = result;
    }

    /// <summary>
    /// The result of making the API call. Can be <see cref="TResult"/>, <see cref="AppwriteError"/> or <see cref="InternalError"/> depending on what happened
    /// </summary>
    public OneOf<TResult, AppwriteError, InternalError> Result { get; }

    /// <summary>
    /// Indicates the API call was successful
    /// </summary>
    public bool Success => Result.IsT0;

    /// <summary>
    /// Indicates there is an error
    /// </summary>
    public bool IsError => Result.IsT1 || Result.IsT2;

    /// <summary>
    /// Indicates that there was an error thrown within Appwrite
    /// </summary>
    public bool IsAppwriteError => Result.IsT1;

    /// <summary>
    /// Indicates that there was an error thrown within the SDK
    /// </summary>
    public bool IsInternalError => Result.IsT2;
}
