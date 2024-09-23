using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Server.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Servers;
public class AccountServer : IAccountServer
{
    private readonly IAccountApi _accountApi;

    private readonly Config _config;

    public AccountServer(IServiceProvider services, Config config)
    {
        _accountApi = services.GetRequiredService<IAccountApi>();
        _config = config;
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> Create(CreateAccountRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.CreateAccount(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Token>> CreateEmailToken(CreateEmailTokenRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.CreateEmailToken(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Token>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Session>> CreateAnonymousSession()
    {
        try
        {
            var result = await _accountApi.CreateAnonymousSession();

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Session>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Session>> CreateEmailPasswordSession(CreateEmailPasswordSessionRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.CreateEmailPasswordSession(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Session>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Session>> CreateSession(CreateSessionRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.CreateSession(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Session>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Token>> CreateMagicUrlToken(CreateMagicUrlTokenRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.CreateMagicUrlToken(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Token>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Session>> UpdateMagicUrlSession(UpdateMagicUrlSessionRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.UpdateMagicUrlSession(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Session>();
        }
    }

    /// <inheritdoc/>
    public AppwriteResult<CreateOauth2Token> CreateOauth2Token(CreateOauth2TokenRequest request)
    {
        try
        {
            request.Validate(true);

            var uri = request.BuildUri(_config.Endpoint, _config.ProjectId);

            return new AppwriteResult<CreateOauth2Token>(new CreateOauth2Token(uri.AbsoluteUri));
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<CreateOauth2Token>();
        }
    }

    /// <inheritdoc/>
    public AppwriteResult<CreateOauth2Session> CreateOauth2Session(CreateOauth2SessionRequest request)
    {
        try
        {
            request.Validate(true);

            var uri = request.BuildUri(_config.Endpoint, _config.ProjectId);

            return new AppwriteResult<CreateOauth2Session>(new CreateOauth2Session(uri.AbsoluteUri));
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<CreateOauth2Session>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Token>> CreatePhoneToken(CreatePhoneTokenRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.CreatePhoneToken(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Token>();
        }
    }
}
