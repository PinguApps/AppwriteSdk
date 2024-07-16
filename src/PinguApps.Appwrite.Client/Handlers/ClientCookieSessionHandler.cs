using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using PinguApps.Appwrite.Client.Internals;

namespace PinguApps.Appwrite.Client.Handlers;
internal class ClientCookieSessionHandler : DelegatingHandler
{
    private readonly Lazy<IAppwriteClient> _appwriteClient;

    public ClientCookieSessionHandler(Lazy<IAppwriteClient> appwriteClient)
    {
        _appwriteClient = appwriteClient;
    }

    private IAppwriteClient AppwriteClient => _appwriteClient.Value;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var result = await base.SendAsync(request, cancellationToken);

        SaveSession(result);

        return result;
    }

    private void SaveSession(HttpResponseMessage response)
    {
        if (response.Headers.TryGetValues("Set-Cookie", out var values))
        {
            var sessionCookie = values.FirstOrDefault(x => x.StartsWith("a_session", StringComparison.OrdinalIgnoreCase) && !x.Contains("legacy", StringComparison.OrdinalIgnoreCase));

            if (sessionCookie is null)
                return;

            var afterEquals = sessionCookie.IndexOf('=') + 1;
            var semicolonIndex = sessionCookie.IndexOf(';', afterEquals);
            var base64 = sessionCookie.Substring(afterEquals, semicolonIndex - afterEquals);

            if (string.Equals(base64, "deleted", StringComparison.OrdinalIgnoreCase))
            {
                AppwriteClient.SetSession(null);
                return;
            }

            var decodedBytes = Convert.FromBase64String(base64);
            var decoded = Encoding.UTF8.GetString(decodedBytes);

            try
            {
                var sessionData = JsonSerializer.Deserialize<CookieSessionData>(decoded);

                if (sessionData is null || sessionData.Id is null || sessionData.Secret is null)
                    return;

                AppwriteClient.SetSession(sessionData.Secret);
            }
            catch (JsonException)
            {
            }
        }
    }
}
