using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PinguApps.Appwrite.Server.Handlers;
internal class HeaderHandler : DelegatingHandler
{
    private readonly string _projectId;
    private readonly string _apiKey;

    public HeaderHandler(string projectId, string apiKey)
    {
        _projectId = projectId;
        _apiKey = apiKey;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("x-appwrite-project", _projectId);
        request.Headers.Add("x-appwrite-key", _apiKey);

        return base.SendAsync(request, cancellationToken);
    }
}
