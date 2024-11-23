using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Converters;

namespace PinguApps.Appwrite.Shared.Enums;

/// <summary>
/// Indicates the sort direction
/// </summary>
[JsonConverter(typeof(UpperCaseEnumConverter))]
public enum SortDirection
{
    Asc,
    Desc
}
