using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Server.Internals;
internal interface ITeamsApi : IBaseApi
{
    [Get("/teams")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<TeamsList>> ListTeams([Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries, string? search);

    [Post("/teams")]
    Task<IApiResponse<Team>> CreateTeam(CreateTeamRequest request);

    [Delete("/teams/{teamId}")]
    Task<IApiResponse> DeleteTeam(string teamId);

    [Get("/teams/{teamId}")]
    Task<IApiResponse<Team>> GetTeam(string teamId);

    [Put("/teams/{teamId}")]
    Task<IApiResponse<Team>> UpdateName(string teamId, UpdateNameRequest request);

    [Get("/teams/{teamId}/memberships")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<MembershipsList>> ListTeamMemberships(string teamId, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries, string? search);

    [Post("/teams/{teamId}/memberships")]
    Task<IApiResponse<Membership>> CreateTeamMembership(string teamId, CreateTeamMembershipRequest request);

    [Delete("/teams/{teamId}/memberships/{membershipId}")]
    Task<IApiResponse> DeleteTeamMembership(string teamId, string membershipId);

    [Get("/teams/{teamId}/memberships/{membershipId}")]
    Task<IApiResponse<Membership>> GetTeamMembership(string teamId, string membershipId);

    [Patch("/teams/{teamId}/memberships/{membershipId}")]
    Task<IApiResponse<Membership>> UpdateMembership(string teamId, string membershipId, UpdateMembershipRequest request);

    [Patch("/teams/{teamId}/memberships/{membershipId}/status")]
    Task<IApiResponse<Membership>> UpdateTeamMembershipStatus(string teamId, string membershipId, UpdateTeamMembershipStatusRequest request);

    [Get("/teams/{teamId}/prefs")]
    Task<IApiResponse<IReadOnlyDictionary<string, string>>> GetTeamPreferences(string teamId);

    [Put("/teams/{teamId}/prefs")]
    Task<IApiResponse<IReadOnlyDictionary<string, string>>> UpdatePreferences(string teamId, UpdatePreferencesRequest request);
}
