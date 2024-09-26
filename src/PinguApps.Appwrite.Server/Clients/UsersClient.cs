﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Shared;

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
    public Task<AppwriteResult> ListUsers() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateUser() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateUserWithArgon2Password() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateUserWithBcryptPassword() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> ListIdentities() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteIdentity() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateUserWithMd5Password() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateUserWithPhpassPassword() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateUserWithScryptPassword() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateUserWithScryptModifiedPassword() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateUserWithShaPassword() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteUser() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> GetUser() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdateEmail() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateUserJwt() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdateUserLabels() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> ListUserLogs() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> ListUserMemberships() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdateMfa() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteAuthenticator() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> ListFactors() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> GetMfaRecoveryCodes() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateMfaRecoveryCodes() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> RegenerateMfaRecoveryCodes() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdateName() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdatePassword() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdatePhone() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> GetUserPreferences() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdateUserPreferences() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteUserSessions() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> ListUserSessions() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateSession() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteUserSession() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdateUserStatus() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> ListUserTargets() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateUserTarget() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteUserTarget() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> GetUserTarget() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdateUserTarget() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> CreateToken() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdateEmailVerification() => throw new NotImplementedException();

    /// <inheritdoc/>
    public Task<AppwriteResult> UpdatePhoneVerification() => throw new NotImplementedException();
}