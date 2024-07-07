using System;
using System.Linq;

namespace PinguApps.Appwrite.Shared.Utils;

/// <summary>
/// Utilities for Appwrite Id properties
/// </summary>
public static class IdUtils
{
    private static readonly Random _random = new();

    /// <summary>
    /// Generates a Hex Timestamp, used in Id's
    /// </summary>
    /// <returns>a string of the hex timestamp for UTC now</returns>
    public static string GetHexTimestamp()
    {
        var dt = DateTimeOffset.UtcNow;
        var sec = dt.ToUnixTimeSeconds();
        var msec = dt.Millisecond;

        return sec.ToString("x") + msec.ToString("x").PadLeft(5, '0');
    }

    /// <summary>
    /// Generates a unique Id under the same rules that Appwrite uses to generate unique Ids
    /// </summary>
    /// <param name="padding">The padding to use - defaults to 7</param>
    /// <returns>A unique Id, in line with Appwrite Id generation rules</returns>
    public static string GenerateUniqueId(int padding = 7)
    {
        var baseId = GetHexTimestamp();

        lock (_random)
        {
            return baseId + string.Concat(Enumerable.Range(0, padding).Select(_ => _random.Next(16).ToString("x")));
        }
    }
}
