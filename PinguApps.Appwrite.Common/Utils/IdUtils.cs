using System;
using System.Linq;

namespace PinguApps.Appwrite.Shared.Utils;
public static class IdUtils
{
    private static readonly Random _random = new Random();

    public static string GetHexTimestamp()
    {
        var dt = DateTimeOffset.UtcNow;
        var sec = dt.ToUnixTimeSeconds();
        var msec = dt.Millisecond;

        return sec.ToString("x") + msec.ToString("x").PadLeft(5, '0');
    }

    public static string GenerateUniqueId(int padding = 7)
    {
        var baseId = GetHexTimestamp();

        lock (_random)
        {
            return baseId + string.Concat(Enumerable.Range(0, padding).Select(_ => _random.Next(16).ToString("x")));
        }
    }
}
