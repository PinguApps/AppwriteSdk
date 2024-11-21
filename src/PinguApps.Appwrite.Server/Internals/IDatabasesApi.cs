using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PinguApps.Appwrite.Shared.Requests.Databases;
using PinguApps.Appwrite.Shared.Responses;
using Refit;

namespace PinguApps.Appwrite.Server.Internals;
internal interface IDatabasesApi : IBaseApi
{
    [Get("/databases")]
    [QueryUriFormat(UriFormat.Unescaped)]
    Task<IApiResponse<DatabasesList>> ListDatabase([Query(CollectionFormat.Multi), AliasAs("queries[]")] IEnumerable<string> queries, string? seearch);

    [Post("/databases")]
    Task<IApiResponse<Database>> CreateDatabase(CreateDatabaseRequest request);

}
