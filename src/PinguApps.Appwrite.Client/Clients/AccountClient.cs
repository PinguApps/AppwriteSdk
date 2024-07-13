using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Client.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;

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
}
