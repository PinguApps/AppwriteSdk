using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentValidation;
using PinguApps.Appwrite.Shared.Attributes;

namespace PinguApps.Appwrite.Shared.Requests;
public abstract class QueryParamBaseRequest<TRequest, TValidator> : BaseRequest<TRequest, TValidator>
    where TRequest : class
    where TValidator : IValidator<TRequest>, new()
{
    public Uri BuildUri(string endpoint, string? projectId)
    {
        var endpointUri = new Uri(endpoint);
        var endpointPath = endpointUri.AbsolutePath;

        var path = Path;

        var urlReplacementProperties = GetType()
            .GetProperties()
            .Where(x => Attribute.IsDefined(x, typeof(UrlReplacementAttribute)));

        foreach (var property in urlReplacementProperties)
        {
            var value = property.GetValue(this);

            if (value is string strValue)
            {
                var attribute = property.GetCustomAttribute<UrlReplacementAttribute>();

                path = path.Replace(attribute.Pattern, strValue);
            }
        }

        var combinedPath = CombinePaths(endpointPath, path);

        var builder = new UriBuilder(endpoint)
        {
            Path = combinedPath
        };

        var queryProperties = GetType()
            .GetProperties()
            .Where(x => Attribute.IsDefined(x, typeof(QueryParameterAttribute)));

        var queries = new List<string>();

        if (projectId is not null)
        {
            queries.Add($"project={projectId}");
        }

        foreach (var property in queryProperties)
        {
            var value = property.GetValue(this);

            if (value is null)
                continue;

            var attribute = property.GetCustomAttribute<QueryParameterAttribute>();

            if (value is IEnumerable<object> values && value is not string)
            {
                foreach (var item in values)
                {
                    queries.Add($"{attribute.Key}={Uri.EscapeDataString(item.ToString())}");
                }
            }
            else
            {
                queries.Add($"{attribute.Key}={Uri.EscapeDataString(value.ToString())}");
            }
        }

        if (queries.Count > 0)
        {
            builder.Query = string.Join("&", queries);
        }

        return builder.Uri;
    }

    static string CombinePaths(string urlPath, string existingPath)
    {
        if (urlPath == "/")
        {
            return existingPath;
        }

        if (!urlPath.EndsWith('/'))
        {
            urlPath += "/";
        }

        if (existingPath.StartsWith('/'))
        {
            existingPath = existingPath.TrimStart('/');
        }

        return urlPath + existingPath;
    }

    protected abstract string Path { get; }
}
