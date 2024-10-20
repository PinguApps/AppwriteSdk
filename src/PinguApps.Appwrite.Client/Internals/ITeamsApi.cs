using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Client.Internals;
internal interface ITeamsApi : IBaseApi
{
    [Get("/teams")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<TeamsList>> ListTeams([Header("x-appwrite-session")] string session, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries, string? search);

    [Post("/teams")]
    Task<IApiResponse<Team>> CreateTeam([Header("x-appwrite-session")] string session, CreateTeamRequest request);

    [Delete("/teams/{teamId}")]
    Task<IApiResponse> DeleteTeam([Header("x-appwrite-session")] string session, string teamId);

    [Get("/teams/{teamId}")]
    Task<IApiResponse<Team>> GetTeam([Header("x-appwrite-session")] string session, string teamId);

    [Put("/teams/{teamId}")]
    Task<IApiResponse<Team>> UpdateName([Header("x-appwrite-session")] string session, string teamId, UpdateNameRequest request);

    [Get("/teams/{teamId}/memberships")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<MembershipsList>> ListTeamMemberships([Header("x-appwrite-session")] string session, string teamId, [Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries, string? search);

    [Post("/teams/{teamId}/memberships")]
    Task<IApiResponse<Membership>> CreateTeamMembership([Header("x-appwrite-session")] string session, string teamId, CreateTeamMembershipRequest request);

    [Delete("/teams/{teamId}/memberships/{membershipId}")]
    Task<IApiResponse> DeleteTeamMembership([Header("x-appwrite-session")] string session, string teamId, string membershipId);

    [Get("/teams/{teamId}/memberships/{membershipId}")]
    Task<IApiResponse<Membership>> GetTeamMembership([Header("x-appwrite-session")] string session, string teamId, string membershipId);

    [Patch("/teams/{teamId}/memberships/{membershipId}")]
    Task<IApiResponse<Membership>> UpdateMembership([Header("x-appwrite-session")] string session, string teamId, string membershipId, UpdateMembershipRequest request);

    [Patch("/teams/{teamId}/memberships/{membershipId}/status")]
    Task<IApiResponse<Membership>> UpdateTeamMembershipStatus(string teamId, string membershipId, UpdateTeamMembershipStatusRequest request);

    [Get("/teams/{teamId}/prefs")]
    Task<IApiResponse<IReadOnlyDictionary<string, string>>> GetTeamPreferences([Header("x-appwrite-session")] string session, string teamId);

    [Put("/teams/{teamId}/prefs")]
    Task<IApiResponse<IReadOnlyDictionary<string, string>>> UpdatePreferences([Header("x-appwrite-session")] string session, string teamId, UpdatePreferencesRequest request);
}
