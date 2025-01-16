namespace PinguApps.Appwrite.Shared.Tests;
public class ResiliencePolicyOptionsTests
{
    [Fact]
    public void DefaultValues_ShouldBeCorrectlySet()
    {
        // Arrange & Act
        var options = new ResiliencePolicyOptions();

        // Assert
        Assert.Equal(3, options.RetryCount);
        Assert.Equal(5, options.CircuitBreakerThreshold);
        Assert.Equal(30, options.CircuitBreakerDurationSeconds);
        Assert.False(options.DisableResilience);
    }

    [Fact]
    public void SleepDurationProvider_DefaultImplementation_ShouldCalculateCorrectly()
    {
        // Arrange
        var options = new ResiliencePolicyOptions();

        // Act & Assert
        // Testing first retry attempt (should be 1 second)
        Assert.Equal(TimeSpan.FromSeconds(1), options.SleepDurationProvider(1));

        // Testing second retry attempt (should be 3 seconds)
        Assert.Equal(TimeSpan.FromSeconds(3), options.SleepDurationProvider(2));

        // Testing third retry attempt (should be 5 seconds)
        Assert.Equal(TimeSpan.FromSeconds(5), options.SleepDurationProvider(3));
    }

    [Fact]
    public void Properties_ShouldBeSettable()
    {
        // Arrange
        var options = new ResiliencePolicyOptions();
        var customSleepDuration = new Func<int, TimeSpan>(retryAttempt => TimeSpan.FromSeconds(retryAttempt));

        // Act
        options.RetryCount = 5;
        options.SleepDurationProvider = customSleepDuration;
        options.CircuitBreakerThreshold = 10;
        options.CircuitBreakerDurationSeconds = 60;
        options.DisableResilience = true;

        // Assert
        Assert.Equal(5, options.RetryCount);
        Assert.Equal(customSleepDuration, options.SleepDurationProvider);
        Assert.Equal(10, options.CircuitBreakerThreshold);
        Assert.Equal(60, options.CircuitBreakerDurationSeconds);
        Assert.True(options.DisableResilience);
    }

    [Fact]
    public void CustomSleepDurationProvider_ShouldWorkCorrectly()
    {
        // Arrange
        var options = new ResiliencePolicyOptions
        {
            SleepDurationProvider = retryAttempt => TimeSpan.FromSeconds(retryAttempt * 10)
        };

        // Act & Assert
        Assert.Equal(TimeSpan.FromSeconds(10), options.SleepDurationProvider(1));
        Assert.Equal(TimeSpan.FromSeconds(20), options.SleepDurationProvider(2));
        Assert.Equal(TimeSpan.FromSeconds(30), options.SleepDurationProvider(3));
    }
}
