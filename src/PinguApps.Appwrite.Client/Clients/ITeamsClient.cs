using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Client.Clients;
public interface ITeamsClient
{
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<TeamsList>> ListTeams(ListTeamsRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<Team>> CreateTeam(CreateTeamRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult> DeleteTeam(DeleteTeamRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<Team>> GetTeam(GetTeamRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<Team>> UpdateName(UpdateNameRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<MembershipsList>> ListTeamMemberships(ListTeamMembershipsRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<Membership>> CreateTeamMembership(CreateTeamMembershipRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult> DeleteTeamMembership(DeleteTeamMembershipRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<Membership>> GetTeamMembership(GetTeamMembershipRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<Membership>> UpdateMembership(UpdateMembershipRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<Membership>> UpdateTeamMembershipStatus(UpdateTeamMembershipStatusRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetTeamPreferences(GetTeamPreferencesRequest request);
    [Obsolete("This method hasn't yet been implemented!")]
    Task<AppwriteResult<IReadOnlyDictionary<string, string>>> UpdatePreferences(UpdatePreferencesRequest request);
}
