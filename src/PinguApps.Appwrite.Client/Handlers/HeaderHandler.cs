using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared;

namespace PinguApps.Appwrite.Client.Handlers;
internal class HeaderHandler : DelegatingHandler
{
    private readonly string _projectId;

    public HeaderHandler(Config config)
    {
        _projectId = config.ProjectId;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("x-appwrite-project", _projectId);

        return base.SendAsync(request, cancellationToken);
    }
}
