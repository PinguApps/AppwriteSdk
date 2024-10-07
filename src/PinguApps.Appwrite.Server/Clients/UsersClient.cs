using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

            var queryStrings = request.Queries?.Select(x => x.GetQueryString()) ?? [];

            var result = await _usersApi.ListUsers(queryStrings, request.Search);

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

            var queryStrings = request.Queries?.Select(x => x.GetQueryString()) ?? [];

            var result = await _usersApi.ListIdentities(queryStrings, request.Search);

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

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> CreateUserWithScryptPassword(CreateUserWithScryptPasswordRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> CreateUserWithScryptModifiedPassword(CreateUserWithScryptModifiedPasswordRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> CreateUserWithShaPassword(CreateUserWithShaPasswordRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteUser(DeleteUserRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> GetUser(GetUserRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> UpdateEmail(UpdateEmailRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Jwt>> CreateUserJwt(CreateUserJwtRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> UpdateUserLabels(UpdateUserLabelsRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<LogsList>> ListUserLogs(ListUserLogsRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<MembershipsList>> ListUserMemberships(ListUserMembershipsRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> UpdateMfa(UpdateMfaRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> DeleteAuthenticator(DeleteAuthenticatorRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<MfaFactors>> ListFactors(ListFactorsRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<MfaRecoveryCodes>> GetMfaRecoveryCodes(GetMfaRecoveryCodesRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<MfaRecoveryCodes>> CreateMfaRecoveryCodes(CreateMfaRecoveryCodesRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<MfaRecoveryCodes>> RegenerateMfaRecoveryCodes(RegenerateMfaRecoveryCodesRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> UpdateName(UpdateNameRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> UpdatePassword(UpdatePasswordRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<User>> UpdatePhone(UpdatePhoneRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetUserPreferences(GetUserPreferencesRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<IReadOnlyDictionary<string, string>>> UpdateUserPreferences(UpdateUserPreferencesRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteUserSessions(DeleteUserSessionsRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<SessionsList>> ListUserSessions(ListUserSessionsRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Session>> CreateSession(CreateSessionRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteUserSession(DeleteUserSessionRequest request) => throw new NotImplementedException();

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
