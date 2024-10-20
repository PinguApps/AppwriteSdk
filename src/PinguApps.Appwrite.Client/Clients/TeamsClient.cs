using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Client.Internals;
using PinguApps.Appwrite.Client.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Client.Clients;

/// <inheritdoc/>
public class TeamsClient : SessionAwareClientBase, ITeamsClient
{
    private readonly ITeamsApi _teamsApi;
    private readonly Config _config;

    public TeamsClient(IServiceProvider services, Config config)
    {
        _teamsApi = services.GetRequiredService<ITeamsApi>();
        _config = config;
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<TeamsList>> ListTeams(ListTeamsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.ListTeams(GetCurrentSessionOrThrow(), RequestUtils.GetQueryStrings(request.Queries), request.Search);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<TeamsList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Team>> CreateTeam(CreateTeamRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.CreateTeam(GetCurrentSessionOrThrow(), request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Team>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteTeam(DeleteTeamRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.DeleteTeam(GetCurrentSessionOrThrow(), request.TeamId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Team>> GetTeam(GetTeamRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.GetTeam(GetCurrentSessionOrThrow(), request.TeamId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Team>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Team>> UpdateName(UpdateNameRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.UpdateName(GetCurrentSessionOrThrow(), request.TeamId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Team>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<MembershipsList>> ListTeamMemberships(ListTeamMembershipsRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.ListTeamMemberships(GetCurrentSessionOrThrow(), request.TeamId, RequestUtils.GetQueryStrings(request.Queries), request.Search);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<MembershipsList>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Membership>> CreateTeamMembership(CreateTeamMembershipRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.CreateTeamMembership(GetCurrentSessionOrThrow(), request.TeamId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Membership>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult> DeleteTeamMembership(DeleteTeamMembershipRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.DeleteTeamMembership(GetCurrentSessionOrThrow(), request.TeamId, request.MembershipId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Membership>> GetTeamMembership(GetTeamMembershipRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.GetTeamMembership(GetCurrentSessionOrThrow(), request.TeamId, request.MembershipId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Membership>();
        }
    }

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Membership>> UpdateMembership(UpdateMembershipRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Membership>> UpdateTeamMembershipStatus(UpdateTeamMembershipStatusRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetTeamPreferences(GetTeamPreferencesRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<IReadOnlyDictionary<string, string>>> UpdatePreferences(UpdatePreferencesRequest request) => throw new NotImplementedException();
}
