using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;
using PinguApps.Appwrite.Shared.Requests.Teams;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Server.Clients;

/// <summary>
/// <para>The Teams service allows you to group users of your project and to enable them to share <see href="https://appwrite.io/docs/advanced/platform/permissions">read and write</see> access to your project resources, such as database documents or storage files.</para>
/// <para>Each user who creates a team becomes the team owner and can delegate the ownership role by inviting a new team member. Only team owners can invite new users to their team.</para>
/// </summary>
public interface ITeamsClient
{
    /// <summary>
    /// Get a list of all the teams in which the current user is a member. You can use the parameters to filter your results.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#list">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The teams list</returns>
    Task<AppwriteResult<TeamsList>> ListTeams(ListTeamsRequest request);

    /// <summary>
    /// Create a new team. The user who creates the team will automatically be assigned as the owner of the team. Only the users with the owner role can invite new members, add new owners and delete or update the team.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#create">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The team</returns>
    Task<AppwriteResult<Team>> CreateTeam(CreateTeamRequest request);

    /// <summary>
    /// Delete a team using its ID. Only team members with the owner role can delete the team.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#delete">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 success code</returns>
    Task<AppwriteResult> DeleteTeam(DeleteTeamRequest request);

    /// <summary>
    /// Get a team by its ID. All team members have read access for this resource.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#get">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The team</returns>
    Task<AppwriteResult<Team>> GetTeam(GetTeamRequest request);

    /// <summary>
    /// Update the team's name by its unique ID.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#updateName">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The team</returns>
    Task<AppwriteResult<Team>> UpdateName(UpdateNameRequest request);

    /// <summary>
    /// Use this endpoint to list a team's members using the team's ID. All team members have read access to this endpoint.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#listMemberships">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The memberships list</returns>
    Task<AppwriteResult<MembershipsList>> ListTeamMemberships(ListTeamMembershipsRequest request);

    /// <summary>
    /// <para>Invite a new member to join your team. Provide an ID for existing users, or invite unregistered users using an email or phone number. If initiated from a Client SDK, Appwrite will send an email or sms with a link to join the team to the invited user, and an account will be created for them if one doesn't exist. If initiated from a Server SDK, the new member will be added automatically to the team.</para>
    /// <para>You only need to provide one of a user ID, email, or phone number. Appwrite will prioritize accepting the user ID > email > phone number if you provide more than one of these parameters.</para>
    /// <para>Use the url parameter to redirect the user from the invitation email to your app. After the user is redirected, use <see cref="UpdateTeamMembershipStatus(UpdateTeamMembershipStatusRequest)"/> to allow the user to accept the invitation to the team.</para>
    /// <para>Please note that to avoid a <see href="https://github.com/OWASP/CheatSheetSeries/blob/master/cheatsheets/Unvalidated_Redirects_and_Forwards_Cheat_Sheet.md">Redirect Attack</see> Appwrite will accept the only redirect URLs under the domains you have added as a platform on the Appwrite Console.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#createMembership">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The membership</returns>
    Task<AppwriteResult<Membership>> CreateTeamMembership(CreateTeamMembershipRequest request);

    /// <summary>
    /// This endpoint allows a user to leave a team or for a team owner to delete the membership of any other team member. You can also use this endpoint to delete a user membership even if it is not accepted.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#deleteMembership">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>204 success code</returns>
    Task<AppwriteResult> DeleteTeamMembership(DeleteTeamMembershipRequest request);

    /// <summary>
    /// Get a team member by the membership unique id. All team members have read access for this resource.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#getMembership">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The membership</returns>
    Task<AppwriteResult<Membership>> GetTeamMembership(GetTeamMembershipRequest request);

    /// <summary>
    /// Modify the roles of a team member. Only team members with the owner role have access to this endpoint. Learn more about <see href="https://appwrite.io/docs/permissions">roles and permissions</see>.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#updateMembership">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The membership</returns>
    Task<AppwriteResult<Membership>> UpdateMembership(UpdateMembershipRequest request);

    /// <summary>
    /// <para>Use this endpoint to allow a user to accept an invitation to join a team after being redirected back to your app from the invitation email received by the user.</para>
    /// <para>If the request is successful, a session for the user is automatically created.</para>
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#updateMembershipStatus">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The membership</returns>
    [Obsolete("This method on the server SDK currently will not work. You can track this bug on the Appwrite Github: https://github.com/appwrite/appwrite/issues/8828", false)]
    Task<AppwriteResult<Membership>> UpdateTeamMembershipStatus(UpdateTeamMembershipStatusRequest request);

    /// <summary>
    /// Get the team's shared preferences by its unique ID. If a preference doesn't need to be shared by all team members, prefer storing them in <see href="https://appwrite.io/docs/references/cloud/client-web/account#getPrefs">user preferences</see>.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#getPrefs">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The preferences</returns>
    Task<AppwriteResult<IReadOnlyDictionary<string, string>>> GetTeamPreferences(GetTeamPreferencesRequest request);

    /// <summary>
    /// Update the team's preferences by its unique ID. The object you pass is stored as is and replaces any previous value. The maximum allowed prefs size is 64kB and throws an error if exceeded.
    /// <para><see href="https://appwrite.io/docs/references/1.6.x/server-rest/teams#updatePrefs">Appwrite Docs</see></para>
    /// </summary>
    /// <param name="request">The request content</param>
    /// <returns>The preferences</returns>
    Task<AppwriteResult<IReadOnlyDictionary<string, string>>> UpdatePreferences(UpdatePreferencesRequest request);
}
