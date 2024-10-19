using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Client.Clients;

/// <summary>
/// <para>The Teams service allows you to group users of your project and to enable them to share <see href="https://appwrite.io/docs/advanced/platform/permissions">read and write</see> access to your project resources, such as database documents or storage files.</para>
/// <para>Each user who creates a team becomes the team owner and can delegate the ownership role by inviting a new team member. Only team owners can invite new users to their team.</para>
/// </summary>
public interface ITeamsClient
{
    /// <summary>
    /// Get a list of all the teams in which the current user is a member. You can use the parameters to filter your results.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/teams#list">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The teams list</returns>
    Task<AppwriteResult<TeamsList>> ListTeams(ListTeamsRequest request);

    /// <summary>
    /// Create a new team. The user who creates the team will automatically be assigned as the owner of the team. Only the users with the owner role can invite new members, add new owners and delete or update the team.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/teams#create">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The team</returns>
    Task<AppwriteResult<Team>> CreateTeam(CreateTeamRequest request);

    /// <summary>
    /// Delete a team using its ID. Only team members with the owner role can delete the team.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/teams#delete">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 success code</returns>
    Task<AppwriteResult> DeleteTeam(DeleteTeamRequest request);

    /// <summary>
    /// Get a team by its ID. All team members have read access for this resource.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/teams#get">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The team</returns>
    Task<AppwriteResult<Team>> GetTeam(GetTeamRequest request);

    /// <summary>
    /// Update the team's name by its unique ID
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/teams#updateName">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The team</returns>
    Task<AppwriteResult<Team>> UpdateName(UpdateNameRequest request);

    /// <summary>
    /// Use this endpoint to list a team's members using the team's ID. All team members have read access to this endpoint.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/client-rest/teams#listMemberships">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The memberships list</returns>
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
