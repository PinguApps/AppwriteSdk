using OneOf;
using OneOf.Types;

namespace PinguApps.Appwrite.Shared;

/// <summary>
/// The result of all API calls
/// </summary>
public class AppwriteResult
{
    public AppwriteResult(OneOf<Success, AppwriteError, InternalError> result)
    {
        Result = result;
    }

    protected AppwriteResult()
    {

    }

    /// <summary>
    /// The result of making the API call. Can be <see cref="OneOf.Types.Success"/>, <see cref="AppwriteError"/> or <see cref="InternalError"/> depending on what happened
    /// </summary>
    public OneOf<Success, AppwriteError, InternalError> Result { get; }

    /// <summary>
    /// Indicates the API call was successful
    /// </summary>
    public virtual bool Success => Result.IsT0;

    /// <summary>
    /// Indicates there is an error
    /// </summary>
    public virtual bool IsError => Result.IsT1 || Result.IsT2;

    /// <summary>
    /// Indicates that there was an error thrown within Appwrite
    /// </summary>
    public virtual bool IsAppwriteError => Result.IsT1;

    /// <summary>
    /// Indicates that there was an error thrown within the SDK
    /// </summary>
    public virtual bool IsInternalError => Result.IsT2;
}


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
