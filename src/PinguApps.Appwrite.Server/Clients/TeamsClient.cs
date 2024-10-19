using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Server.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Clients;

/// <inheritdoc/>
public class TeamsClient : ITeamsClient
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

            var result = await _teamsApi.ListTeams(RequestUtils.GetQueryStrings(request.Queries), request.Search);

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

            var result = await _teamsApi.CreateTeam(request);

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

            var result = await _teamsApi.DeleteTeam(request.TeamId);

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

            var result = await _teamsApi.GetTeam(request.TeamId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Team>();
        }
    }

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Team>> UpdateName(UpdateNameRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<MembershipsList>> ListTeamMemberships(ListTeamMembershipsRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Membership>> CreateTeamMembership(CreateTeamMembershipRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult> DeleteTeamMembership(DeleteTeamMembershipRequest request) => throw new NotImplementedException();

    [ExcludeFromCodeCoverage]
    /// <inheritdoc/>
    public Task<AppwriteResult<Membership>> GetTeamMembership(GetTeamMembershipRequest request) => throw new NotImplementedException();

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
