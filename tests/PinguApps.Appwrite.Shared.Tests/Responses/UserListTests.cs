using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class UserListTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var total = 5;
        var id = "5e5ea5c16897e";
        var createdAt = DateTime.UtcNow;
        var updatedAt = DateTime.UtcNow;
        var name = "John Doe";
        var password = "$argon2id$v=19$m=2048,t=4,p=3$aUZjLnliVWRINmFNTWMudg$5S+x+7uA31xFnrHFT47yFwcJeaP0w92L/4LdgrVRXxE";
        var hash = "argon2";
        var hashOptions = new HashOptions("argon2", 65536, 4, 3);
        var registration = DateTime.UtcNow;
        var status = true;
        var labels = new List<string> { "vip" };
        var passwordUpdate = DateTime.UtcNow;
        var email = "john@appwrite.io";
        var phone = "+4930901820";
        var emailVerification = true;
        var phoneVerification = true;
        var mfa = true;
        var prefs = new Dictionary<string, string>();
        var targets = new List<Target> { new Target("259125845563242502", DateTime.UtcNow, DateTime.UtcNow, "Aegon apple token", "259125845563242502", "259125845563242502", TargetProviderType.Email, "token") };
        var accessedAt = DateTime.UtcNow;

        // Act
        var user = new User(id, createdAt, updatedAt, name, password, hash, hashOptions, registration, status, labels, passwordUpdate, email, phone, emailVerification, phoneVerification, mfa, prefs, targets, accessedAt);
        var usersList = new UsersList(total, new List<User> { user });

        // Assert
        Assert.Equal(total, usersList.Total);
        Assert.Single(usersList.Users);
        var extractedUser = usersList.Users[0];

        Assert.Equal(id, extractedUser.Id);
        Assert.Equal(createdAt.ToUniversalTime(), extractedUser.CreatedAt.ToUniversalTime());
        Assert.Equal(updatedAt.ToUniversalTime(), extractedUser.UpdatedAt.ToUniversalTime());
        Assert.Equal(name, extractedUser.Name);
        Assert.Equal(password, extractedUser.Password);
        Assert.Equal(hash, extractedUser.Hash);
        Assert.Equal(hashOptions, extractedUser.HashOptions);
        Assert.Equal(registration.ToUniversalTime(), extractedUser.Registration.ToUniversalTime());
        Assert.Equal(status, extractedUser.Status);
        Assert.Equal(labels, extractedUser.Labels);
        Assert.NotNull(extractedUser.PasswordUpdate);
        Assert.Equal(passwordUpdate.ToUniversalTime(), extractedUser.PasswordUpdate.Value.ToUniversalTime());
        Assert.Equal(email, extractedUser.Email);
        Assert.Equal(phone, extractedUser.Phone);
        Assert.Equal(emailVerification, extractedUser.EmailVerification);
        Assert.Equal(phoneVerification, extractedUser.PhoneVerification);
        Assert.Equal(mfa, extractedUser.Mfa);
        Assert.Equal(prefs, extractedUser.Prefs);
        Assert.Equal(targets, extractedUser.Targets);
        Assert.Equal(accessedAt.ToUniversalTime(), extractedUser.AccessedAt.ToUniversalTime());
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var usersList = JsonSerializer.Deserialize<UsersList>(Constants.UsersListResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(usersList);
        Assert.Equal(5, usersList.Total);
        Assert.Single(usersList.Users);
        var user = usersList.Users[0];

        Assert.Equal("5e5ea5c16897e", user.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.UpdatedAt.ToUniversalTime());
        Assert.Equal("John Doe", user.Name);
        Assert.Equal("$argon2id$v=19$m=2048,t=4,p=3$aUZjLnliVWRINmFNTWMudg$5S+x+7uA31xFnrHFT47yFwcJeaP0w92L/4LdgrVRXxE", user.Password);
        Assert.Equal("argon2", user.Hash);
        Assert.NotNull(user.HashOptions);
        Assert.Equal("argon2", user.HashOptions.Type);
        Assert.Equal(65536, user.HashOptions.MemoryCost);
        Assert.Equal(4, user.HashOptions.TimeCost);
        Assert.Equal(3, user.HashOptions.Threads);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.Registration.ToUniversalTime());
        Assert.True(user.Status);
        Assert.Single(user.Labels);
        Assert.Equal("vip", user.Labels[0]);
        Assert.NotNull(user.PasswordUpdate);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.PasswordUpdate.Value.ToUniversalTime());
        Assert.Equal("john@appwrite.io", user.Email);
        Assert.Equal("+4930901820", user.Phone);
        Assert.True(user.EmailVerification);
        Assert.True(user.PhoneVerification);
        Assert.True(user.Mfa);
        Assert.NotNull(user.Prefs);
        Assert.Single(user.Targets);
        var target = user.Targets[0];
        Assert.Equal("259125845563242502", target.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), target.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), target.UpdatedAt.ToUniversalTime());
        Assert.Equal("Aegon apple token", target.Name);
        Assert.Equal("259125845563242502", target.UserId);
        Assert.Equal("259125845563242502", target.ProviderId);
        Assert.Equal(TargetProviderType.Email, target.ProviderType);
        Assert.Equal("token", target.Identifier);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.AccessedAt.ToUniversalTime());
    }
}
