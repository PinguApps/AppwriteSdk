using System.Text.Json;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class MembershipListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var id = "5e5ea5c16897e";
        var createdAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var updatedAt = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var userId = "5e5ea5c16897e";
        var userName = "John Doe";
        var userEmail = "john@appwrite.io";
        var teamId = "5e5ea5c16897e";
        var teamName = "VIP";
        var invited = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var joined = DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime();
        var confirm = false;
        var mfa = false;
        var roles = new List<string> { "owner" };

        // Act
        var membership = new Membership(id, createdAt, updatedAt, userId, userName, userEmail, teamId, teamName, invited, joined, confirm, mfa, roles);
        var membershipsList = new MembershipsList(total, new List<Membership> { membership });

        // Assert
        Assert.Equal(total, membershipsList.Total);
        Assert.Single(membershipsList.Memberships);
        var extractedMembership = membershipsList.Memberships[0];

        Assert.Equal(id, extractedMembership.Id);
        Assert.Equal(createdAt, extractedMembership.CreatedAt);
        Assert.Equal(updatedAt, extractedMembership.UpdatedAt);
        Assert.Equal(userId, extractedMembership.UserId);
        Assert.Equal(userName, extractedMembership.UserName);
        Assert.Equal(userEmail, extractedMembership.UserEmail);
        Assert.Equal(teamId, extractedMembership.TeamId);
        Assert.Equal(teamName, extractedMembership.TeamName);
        Assert.Equal(invited, extractedMembership.Invited);
        Assert.Equal(joined, extractedMembership.Joined);
        Assert.Equal(confirm, extractedMembership.Confirm);
        Assert.Equal(mfa, extractedMembership.Mfa);
        Assert.Equal(roles, extractedMembership.Roles);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var membershipsList = JsonSerializer.Deserialize<MembershipsList>(TestConstants.MembershipsListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(membershipsList);
        Assert.Equal(5, membershipsList.Total);
        Assert.Single(membershipsList.Memberships);
        var membership = membershipsList.Memberships[0];

        Assert.Equal("5e5ea5c16897e", membership.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), membership.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), membership.UpdatedAt.ToUniversalTime());
        Assert.Equal("5e5ea5c16897e", membership.UserId);
        Assert.Equal("John Doe", membership.UserName);
        Assert.Equal("john@appwrite.io", membership.UserEmail);
        Assert.Equal("5e5ea5c16897e", membership.TeamId);
        Assert.Equal("VIP", membership.TeamName);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), membership.Invited.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), membership.Joined.ToUniversalTime());
        Assert.False(membership.Confirm);
        Assert.False(membership.Mfa);
        Assert.Single(membership.Roles);
        Assert.Equal("owner", membership.Roles[0]);
    }
}
