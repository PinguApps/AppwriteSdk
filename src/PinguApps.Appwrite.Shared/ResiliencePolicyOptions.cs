using System;

namespace PinguApps.Appwrite.Shared;
public class ResiliencePolicyOptions
{
    public int RetryCount { get; set; } = 3;
    public Func<int, TimeSpan> SleepDurationProvider { get; set; } = retryAttempt => TimeSpan.FromSeconds((retryAttempt - 1) * 2 + 1);
    public int CircuitBreakerThreshold { get; set; } = 5;
    public int CircuitBreakerDurationSeconds { get; set; } = 30;
    public bool DisableResilience { get; set; } = false;
}
