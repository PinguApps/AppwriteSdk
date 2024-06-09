﻿using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Appwrite.Client.Handlers;
internal class HeaderHandler : DelegatingHandler
{
    private readonly string _projectId;

    public HeaderHandler(string projectId)
    {
        _projectId = projectId;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        request.Headers.Add("X-Appwrite-Project", _projectId);

        return base.SendAsync(request, cancellationToken);
    }
}
