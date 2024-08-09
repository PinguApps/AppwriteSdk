using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Client.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Client;

public class AccountClient : IAccountClient, ISessionAware
{
    private readonly IAccountApi _accountApi;

    public AccountClient(IServiceProvider services)
    {
        _accountApi = services.GetRequiredService<IAccountApi>();
    }

    string? ISessionAware.Session { get; set; }

    ISessionAware? _sessionAware;
    public string? Session => GetSession();
    private string? GetSession()
    {
        if (_sessionAware is null)
        {
            _sessionAware = this;
        }

        return _sessionAware.Session;
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> Get()
    {
        try
        {
            var result = await _accountApi.GetAccount(Session);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
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
    public async Task<AppwriteResult<User>> UpdateEmail(UpdateEmailRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.UpdateEmail(Session, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> UpdateName(UpdateNameRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.UpdateName(Session, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> UpdatePassword(UpdatePasswordRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.UpdatePassword(Session, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> UpdatePhone(UpdatePhoneRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.UpdatePhone(Session, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetAccountPreferences()
    {
        try
        {
            var result = await _accountApi.GetAccountPreferences(Session);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<IReadOnlyDictionary<string, string>>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> UpdatePreferences(UpdatePreferencesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.UpdatePreferences(Session, request);

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
    public async Task<AppwriteResult<Session>> GetSession(string sessionId = "current")
    {
        try
        {
            var result = await _accountApi.GetSession(Session, sessionId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Session>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Session>> UpdateSession(string sessionId = "current")
    {
        try
        {
            var result = await _accountApi.UpdateSession(Session, sessionId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Session>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Token>> CreateEmailVerification(CreateEmailVerificationRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.CreateEmailVerification(Session, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Token>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Token>> CreateEmailVerificationConfirmation(CreateEmailVerificationConfirmationRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.CreateEmailVerificationConfirmation(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Token>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Jwt>> CreateJwt()
    {
        try
        {
            var result = await _accountApi.CreateJwt(Session);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Jwt>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<LogsList>> ListLogs(List<Query>? queries = null)
    {
        try
        {
            var queryStrings = queries?.Select(x => x.GetQueryString()) ?? [];

            var result = await _accountApi.ListLogs(Session, queryStrings);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<LogsList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<MfaType>> AddAuthenticator(AddAuthenticatorRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.AddAuthenticator(Session, request.Type);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<MfaType>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> VerifyAuthenticator(VerifyAuthenticatorRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.VerifyAuthenticator(Session, request.Type, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> UpdateMfa(UpdateMfaRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.UpdateMfa(Session, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteAuthenticator(DeleteAuthenticatorRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.DeleteAuthenticator(Session, request.Type, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<MfaChallenge>> Create2faChallenge(Create2faChallengeRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _accountApi.Create2faChallenge(Session, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<MfaChallenge>();
        }
    }
}
