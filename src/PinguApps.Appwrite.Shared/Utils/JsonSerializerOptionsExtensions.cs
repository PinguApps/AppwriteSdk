using System.Linq;
using System.Text.Json;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Utils;
public static class JsonSerializerOptionsExtensions
{
    public static bool IsInsideSdk(this JsonSerializerOptions options) => options.Converters.Any(c => c is SdkMarkerConverter);
}
