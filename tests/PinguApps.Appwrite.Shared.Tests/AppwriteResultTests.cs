using OneOf;
using OneOf.Types;

namespace PinguApps.Appwrite.Shared.Tests;

public class AppwriteResultTests
{
    [Fact]
    public void Constructor_WithTResult_SuccessIsTrue()
    {
        var result = new AppwriteResult(OneOf<Success, AppwriteError, InternalError>.FromT0(new Success()));

        Assert.True(result.Success);
        Assert.False(result.IsError);
        Assert.False(result.IsAppwriteError);
        Assert.False(result.IsInternalError);
        Assert.IsType<Success>(result.Result.AsT0);
    }

    [Fact]
    public void Constructor_WithAppwriteError_IsAppwriteErrorIsTrue()
    {
        var result = new AppwriteResult(OneOf<Success, AppwriteError, InternalError>.FromT1(new AppwriteError("Message", 500, "Type", "Version")));

        Assert.False(result.Success);
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
        Assert.False(result.IsInternalError);
        Assert.Equal("Message", result.Result.AsT1.Message);
    }

    [Fact]
    public void Constructor_WithInternalError_IsInternalErrorIsTrue()
    {
        var result = new AppwriteResult(OneOf<Success, AppwriteError, InternalError>.FromT2(new InternalError("Message")));

        Assert.False(result.Success);
        Assert.True(result.IsError);
        Assert.False(result.IsAppwriteError);
        Assert.True(result.IsInternalError);
        Assert.Equal("Message", result.Result.AsT2.Message);
    }

    [Fact]
    public void GenericConstructor_WithTResult_SuccessIsTrue()
    {
        var result = new AppwriteResult<string>(OneOf<string, AppwriteError, InternalError>.FromT0("Success"));

        Assert.True(result.Success);
        Assert.False(result.IsError);
        Assert.False(result.IsAppwriteError);
        Assert.False(result.IsInternalError);
        Assert.Equal("Success", result.Result.AsT0);
    }

    [Fact]
    public void GenericConstructor_WithAppwriteError_IsAppwriteErrorIsTrue()
    {
        var result = new AppwriteResult<string>(OneOf<string, AppwriteError, InternalError>.FromT1(new AppwriteError("Message", 500, "Type", "Version")));

        Assert.False(result.Success);
        Assert.True(result.IsError);
        Assert.True(result.IsAppwriteError);
        Assert.False(result.IsInternalError);
        Assert.Equal("Message", result.Result.AsT1.Message);
    }

    [Fact]
    public void GenericConstructor_WithInternalError_IsInternalErrorIsTrue()
    {
        var result = new AppwriteResult<string>(OneOf<string, AppwriteError, InternalError>.FromT2(new InternalError("Message")));

        Assert.False(result.Success);
        Assert.True(result.IsError);
        Assert.False(result.IsAppwriteError);
        Assert.True(result.IsInternalError);
        Assert.Equal("Message", result.Result.AsT2.Message);
    }
}
