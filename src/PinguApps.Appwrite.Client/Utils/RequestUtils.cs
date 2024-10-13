using System.Collections.Generic;
using System.Linq;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Client.Utils;
internal static class RequestUtils
{
    internal static IEnumerable<string> GetQueryStrings(List<Query>? queries) =>
        queries?.Select(x => x.GetQueryString()) ?? [];
}
