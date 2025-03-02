using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using PinguApps.Appwrite.Shared;

namespace PinguApps.Appwrite.Server.Handlers;
internal class HeaderHandler : DelegatingHandler
{
    private readonly string _projectId;
    private readonly string _apiKey;

    public HeaderHandler([FromKeyedServices("Server")] Config config)
    {
        if (config.ApiKey is null)
            throw new ArgumentNullException("config.ApiKey");

        _projectId = config.ProjectId;
        _apiKey = config.ApiKey;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("X-Appwrite-Project", _projectId);
        request.Headers.Add("X-Appwrite-Key", _apiKey);

        if (request.Headers.UserAgent.Count > 0)
        {
            var originalUserAgent = request.Headers.UserAgent.ToString();

            request.Headers.Add("X-Forwarded-User-Agent", originalUserAgent);

            request.Headers.UserAgent.Clear();
        }

        return base.SendAsync(request, cancellationToken);
    }
}
