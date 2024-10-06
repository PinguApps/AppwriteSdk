using System.Text.Json;
using PinguApps.Appwrite.Shared.Enums;
using PinguApps.Appwrite.Shared.Responses;

namespace PinguApps.Appwrite.Shared.Tests.Responses;
public class UserTests
{
    [Fact]
    public void Constructor_AssignsPropertiesCorrectly()
    {
        // Arrange
        var id = "testId";
        var createdAt = DateTime.UtcNow;
        var updatedAt = DateTime.UtcNow;
        var name = "Test User";
        var password = "";
        var hash = "";
        var hashOptions = new HashOptions("type", 6, 5, 4);
        var registration = DateTime.UtcNow;
        var status = true;
        var labels = new List<string> { "label1", "label2" };
        var passwordUpdate = DateTime.UtcNow;
        var email = "test@example.com";
        var phone = "1234567890";
        var emailVerification = true;
        var phoneVerification = false;
        var mfa = true;
        var prefs = new Dictionary<string, string> { { "theme", "dark" } };
        var targets = new List<Target> { new Target("259125845563242502", DateTime.UtcNow, DateTime.UtcNow, "Aegon apple token", "259125845563242502", "259125845563242502", TargetProviderType.Email, "token") };
        var accessedAt = DateTime.UtcNow;

        // Act
        var user = new User(id, createdAt, updatedAt, name, password, hash, hashOptions, registration, status, labels, passwordUpdate,
                            email, phone, emailVerification, phoneVerification, mfa, prefs, targets, accessedAt);

        // Assert
        Assert.Equal(id, user.Id);
        Assert.Equal(createdAt, user.CreatedAt);
        Assert.Equal(updatedAt, user.UpdatedAt);
        Assert.Equal(name, user.Name);
        Assert.Equal(registration, user.Registration);
        Assert.Equal(status, user.Status);
        Assert.Equal(labels, user.Labels);
        Assert.Equal(passwordUpdate, user.PasswordUpdate);
        Assert.Equal(email, user.Email);
        Assert.Equal(phone, user.Phone);
        Assert.Equal(emailVerification, user.EmailVerification);
        Assert.Equal(phoneVerification, user.PhoneVerification);
        Assert.Equal(mfa, user.Mfa);
        Assert.Equal(prefs, user.Prefs);
        Assert.Equal(targets, user.Targets);
        Assert.Equal(accessedAt, user.AccessedAt);
    }

    [Fact]
    public void CanBeDeserialized_FromJson()
    {
        // Act
        var user = JsonSerializer.Deserialize<User>(Constants.UserResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        // Assert
        Assert.NotNull(user);
        Assert.Equal("5e5ea5c16897e", user.Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.UpdatedAt.ToUniversalTime());
        Assert.Equal("John Doe", user.Name);
        Assert.NotNull(user.Password);
        Assert.Equal("$argon2id$v=19$m=2048,t=4,p=3$aUZjLnliVWRINmFNTWMudg$5S+x+7uA31xFnrHFT47yFwcJeaP0w92L/4LdgrVRXxE", user.Password);
        Assert.NotNull(user.Hash);
        Assert.Equal("argon2", user.Hash);
        Assert.NotNull(user.HashOptions);
        Assert.Equal("argon2", user.HashOptions.Type);
        Assert.Equal(65536, user.HashOptions.MemoryCost);
        Assert.Equal(4, user.HashOptions.TimeCost);
        Assert.Equal(3, user.HashOptions.Threads);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.Registration.ToUniversalTime());
        Assert.True(user.Status);
        Assert.Contains("vip", user.Labels);
        Assert.NotNull(user.PasswordUpdate);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.PasswordUpdate.Value.ToUniversalTime());
        Assert.Equal("john@appwrite.io", user.Email);
        Assert.Equal("+4930901820", user.Phone);
        Assert.True(user.EmailVerification);
        Assert.True(user.PhoneVerification);
        Assert.True(user.Mfa);
        Assert.Contains("pref1", user.Prefs);
        Assert.Equal("val1", user.Prefs["pref1"]);
        Assert.Single(user.Targets);
        Assert.Equal("259125845563242502", user.Targets[0].Id);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.Targets[0].CreatedAt.ToUniversalTime());
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.Targets[0].UpdatedAt.ToUniversalTime());
        Assert.Equal("Aegon apple token", user.Targets[0].Name);
        Assert.Equal("259125845563242502", user.Targets[0].UserId);
        Assert.Equal("259125845563242502", user.Targets[0].ProviderId);
        Assert.Equal(TargetProviderType.Email, user.Targets[0].ProviderType);
        Assert.Equal("token", user.Targets[0].Identifier);
        Assert.NotNull(user.AccessedAt);
        Assert.Equal(DateTime.Parse("2020-10-15T06:38:00.000+00:00").ToUniversalTime(), user.AccessedAt.Value.ToUniversalTime());
    }
}
