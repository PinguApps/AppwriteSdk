using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PinguApps.Appwrite.Shared.Responses;
public record IndexesList(
    [property: JsonPropertyName("total")] int Total,
    [property: JsonPropertyName("indexes")] IReadOnlyList<Index> Indexes
);
