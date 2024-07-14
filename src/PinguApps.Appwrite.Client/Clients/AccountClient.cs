using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Client.Clients;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Client.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Client;

public class AccountClient : IAccountClient, ISessionAware
{
    private readonly IAccountApi _accountApi;
    private readonly bool _saveSession;

    public AccountClient(IServiceProvider services, bool saveSession)
    {
        _accountApi = services.GetRequiredService<IAccountApi>();
        _saveSession = saveSession;
    }

    string? ISessionAware.Session { get; set; }

    public event EventHandler<string?>? SessionChanged;

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

    private void SaveSession<T>(IApiResponse<T> response)
    {
        if (_saveSession && response.IsSuccessStatusCode && SessionChanged is not null)
        {
            if (response.Headers.TryGetValues("Set-Cookie", out var values))
            {
                var sessionCookie = values.FirstOrDefault(x => x.StartsWith("a_session", StringComparison.OrdinalIgnoreCase) && !x.Contains("legacy", StringComparison.OrdinalIgnoreCase));

                if (sessionCookie is null)
                    return;

                var base64 = sessionCookie.Split('=')[1].Split(';')[0];

                var decodedBytes = Convert.FromBase64String(base64);
                var decoded = Encoding.UTF8.GetString(decodedBytes);

                var sessionData = JsonSerializer.Deserialize<CookieSessionData>(decoded);

                if (sessionData is null)
                    return;

                SessionChanged.Invoke(this, sessionData.Secret);
            }
        }
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

            SaveSession(result);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Session>();
        }
    }
}
