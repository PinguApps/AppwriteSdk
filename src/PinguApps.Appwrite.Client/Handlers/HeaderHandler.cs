using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Shared;

namespace PinguApps.Appwrite.Client.Handlers;
internal class HeaderHandler : DelegatingHandler
{
    private readonly string _projectId;

    public HeaderHandler([FromKeyedServices("Client")] Config config)
    {
        _projectId = config.ProjectId;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("X-Appwrite-Project", _projectId);

        return base.SendAsync(request, cancellationToken);
    }
}
