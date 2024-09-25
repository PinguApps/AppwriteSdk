using OneOf;

namespace PinguApps.Appwrite.Shared;

/// <inheritdoc/>
/// <typeparam name="TResult">the type of response expected on success</typeparam>
public class AppwriteResult<TResult> : AppwriteResult
{
    public AppwriteResult(OneOf<TResult, AppwriteError, InternalError> result)
    {
        Result = result;
    }

    /// <summary>
    /// /// The result of making the API call. Can be <see cref="TResult"/>, <see cref="AppwriteError"/> or <see cref="InternalError"/> depending on what happened
    /// </summary>
    public new OneOf<TResult, AppwriteError, InternalError> Result { get; }

    /// <inheritdoc/>
    public override bool Success => Result.IsT0;

    /// <inheritdoc/>
    public override bool IsError => Result.IsT1 || Result.IsT2;

    /// <inheritdoc/>
    public override bool IsAppwriteError => Result.IsT1;

    /// <inheritdoc/>
    public override bool IsInternalError => Result.IsT2;
}
