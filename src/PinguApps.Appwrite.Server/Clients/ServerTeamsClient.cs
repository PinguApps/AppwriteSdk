﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Server.Internals;
using PinguApps.Appwrite.Server.Utils;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Clients;

/// <inheritdoc/>
public class ServerTeamsClient : IServerTeamsClient
{
    private readonly ITeamsApi _teamsApi;
    private readonly Config _config;

    internal ServerTeamsClient(ITeamsApi teamsApi, [FromKeyedServices("Server")] Config config)
    {
        _teamsApi = teamsApi;
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

    /// <inheritdoc/>
    public async Task<AppwriteResult<Team>> UpdateName(UpdateNameRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.UpdateName(request.TeamId, request);

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

            var result = await _teamsApi.ListTeamMemberships(request.TeamId, RequestUtils.GetQueryStrings(request.Queries), request.Search);

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
            request.ValidationContext = ValidationContext.Server;
            request.Validate(true);

            var result = await _teamsApi.CreateTeamMembership(request.TeamId, request);

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

            var result = await _teamsApi.DeleteTeamMembership(request.TeamId, request.MembershipId);

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

            var result = await _teamsApi.GetTeamMembership(request.TeamId, request.MembershipId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Membership>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<Membership>> UpdateMembership(UpdateMembershipRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.UpdateMembership(request.TeamId, request.MembershipId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<Membership>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetTeamPreferences(GetTeamPreferencesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.GetTeamPreferences(request.TeamId);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<IReadOnlyDictionary<string, string>>();
        }
    }

    /// <inheritdoc/>
    public async Task<AppwriteResult<IReadOnlyDictionary<string, string>>> UpdatePreferences(UpdatePreferencesRequest request)
    {
        try
        {
            request.Validate(true);

            var result = await _teamsApi.UpdatePreferences(request.TeamId, request);

            return result.GetApiResponse();
        }
        catch (Exception e)
        {
            return e.GetExceptionResponse<IReadOnlyDictionary<string, string>>();
        }
    }
}
