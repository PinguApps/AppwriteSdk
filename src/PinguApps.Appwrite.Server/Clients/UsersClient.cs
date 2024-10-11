using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Server.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Users;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Clients;
public class UsersClient : IUsersClient
{
    private readonly IUsersApi _usersApi;
    private readonly Config _config;

    public UsersClient(IServiceProvider services, Config config)
    {
        _usersApi = services.GetRequiredService<IUsersApi>();
        _config = config;
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<UsersList>> ListUsers(ListUsersRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.ListUsers(RequestUtils.GetQueryStrings(request.Queries), request.Search);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<UsersList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> CreateUser(CreateUserRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateUser(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> CreateUserWithArgon2Password(CreateUserWithArgon2PasswordRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateUserWithArgon2Password(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> CreateUserWithBcryptPassword(CreateUserWithBcryptPasswordRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateUserWithBcryptPassword(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<IdentitiesList>> ListIdentities(ListIdentitiesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.ListIdentities(RequestUtils.GetQueryStrings(request.Queries), request.Search);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<IdentitiesList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteIdentity(DeleteIdentityRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.DeleteIdentity(request.IdentityId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> CreateUserWithMd5Password(CreateUserWithMd5PasswordRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateUserWithMd5Password(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> CreateUserWithPhpassPassword(CreateUserWithPhpassPasswordRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateUserWithPhpassPassword(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> CreateUserWithScryptPassword(CreateUserWithScryptPasswordRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateUserWithScryptPassword(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> CreateUserWithScryptModifiedPassword(CreateUserWithScryptModifiedPasswordRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateUserWithScryptModifiedPassword(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> CreateUserWithShaPassword(CreateUserWithShaPasswordRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateUserWithShaPassword(request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteUser(DeleteUserRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.DeleteUser(request.UserId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> GetUser(GetUserRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.GetUser(request.UserId);

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

            var result = await _usersApi.UpdateEmail(request.UserId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Jwt>> CreateUserJwt(CreateUserJwtRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateUserJwt(request.UserId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Jwt>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> UpdateUserLabels(UpdateUserLabelsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.UpdateUserLabels(request.UserId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<LogsList>> ListUserLogs(ListUserLogsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.ListUserLogs(request.UserId, RequestUtils.GetQueryStrings(request.Queries));

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<LogsList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<MembershipsList>> ListUserMemberships(ListUserMembershipsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.ListUserMemberships(request.UserId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<MembershipsList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> UpdateMfa(UpdateMfaRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.UpdateMfa(request.UserId, request);

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

            var result = await _usersApi.DeleteAuthenticator(request.UserId, request.Type);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<MfaFactors>> ListFactors(ListFactorsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.ListFactors(request.UserId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<MfaFactors>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<MfaRecoveryCodes>> GetMfaRecoveryCodes(GetMfaRecoveryCodesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.GetMfaRecoveryCodes(request.UserId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<MfaRecoveryCodes>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<MfaRecoveryCodes>> CreateMfaRecoveryCodes(CreateMfaRecoveryCodesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateMfaRecoveryCodes(request.UserId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<MfaRecoveryCodes>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<MfaRecoveryCodes>> RegenerateMfaRecoveryCodes(RegenerateMfaRecoveryCodesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.RegenerateMfaRecoveryCodes(request.UserId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<MfaRecoveryCodes>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<User>> UpdateName(UpdateNameRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.UpdateName(request.UserId, request);

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

            var result = await _usersApi.UpdatePassword(request.UserId, request);

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

            var result = await _usersApi.UpdatePhone(request.UserId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<User>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetUserPreferences(GetUserPreferencesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.GetUserPreferences(request.UserId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<IReadOnlyDictionary<string, string>>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<IReadOnlyDictionary<string, string>>> UpdateUserPreferences(UpdateUserPreferencesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.UpdateUserPreferences(request.UserId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<IReadOnlyDictionary<string, string>>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteUserSessions(DeleteUserSessionsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.DeleteUserSessions(request.UserId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<SessionsList>> ListUserSessions(ListUserSessionsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.ListUserSessions(request.UserId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<SessionsList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Session>> CreateSession(CreateSessionRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.CreateSession(request.UserId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Session>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteUserSession(DeleteUserSessionRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _usersApi.DeleteUserSession(request.UserId, request.SessionId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> UpdateUserStatus(UpdateUserStatusRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<TargetList>> ListUserTargets(ListUserTargetsRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Target>> CreateUserTarget(CreateUserTargetRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteUserTarget(DeleteUserTargetRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Target>> GetUserTarget(GetUserTargetRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Target>> UpdateUserTarget(UpdateUserTargertRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Token>> CreateToken(CreateTokenRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> UpdateEmailVerification(UpdateEmailVerificationRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> UpdatePhoneVerification(UpdatePhoneVerificationRequest request) => throw new NotImplementedException();
}
