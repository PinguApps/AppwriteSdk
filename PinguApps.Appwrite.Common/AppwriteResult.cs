using OneOf;

namespace PinguApps.Appwrite.Shared;
public class AppwriteResult<TResult>
{
    public AppwriteResult(OneOf<TResult, AppwriteError, InternalError> result)
    {
        Result = result;
    }

    public OneOf<TResult, AppwriteError, InternalError> Result { get; }
    public bool Success => Result.IsT0;
    public bool IsError => Result.IsT1 || Result.IsT2;
    public bool IsAppwriteError => Result.IsT1;
    public bool IsInternalError => Result.IsT2;
}
