using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Serialization;
using PinguApps.Appwrite.Shared.Utils;

namespace PinguApps.Appwrite.Shared.Requests.Databases;

/// <summary>
/// Builder interface for creating document requests
/// </summary>
public interface ICreateDocumentRequestBuilder
{
    /// <summary>
    /// Sets the database identifier
    /// </summary>
    ICreateDocumentRequestBuilder WithDatabaseId(string databaseId);

    /// <summary>
    /// Sets the collection identifier
    /// </summary>
    ICreateDocumentRequestBuilder WithCollectionId(string collectionId);

    /// <summary>
    /// Sets the document identifier
    /// </summary>
    ICreateDocumentRequestBuilder WithDocumentId(string documentId);

    /// <summary>
    /// Sets the document permissions
    /// </summary>
    ICreateDocumentRequestBuilder WithPermissions(List<Permission> permissions);

    /// <summary>
    /// Adds a permission for the document
    /// </summary>
    ICreateDocumentRequestBuilder AddPermission(Permission permission);

    /// <summary>
    /// Adds a field to the document data
    /// </summary>
    ICreateDocumentRequestBuilder AddField(string name, object? value);

    /// <summary>
    /// Builds the document request
    /// </summary>
    CreateDocumentRequest Build();

    /// <summary>
    /// Adds your given data do the document data
    /// </summary>
    /// <typeparam name="T">The type of your data object</typeparam>
    /// <param name="data">The data</param>
    /// <param name="options">Options</param>
    ICreateDocumentRequestBuilder WithData<T>(T? data, Action<WithDataOptions>? options = null) where T : class;

    /// <summary>
    /// Options for adding data to the document
    /// </summary>
    public class WithDataOptions
    {
        /// <summary>
        /// Whether to ignore null values
        /// </summary>
        public bool IgnoreNullValues { get; set; } = true;

        /// <summary>
        /// A filter for properties
        /// </summary>
        public Func<PropertyInfo, bool>? PropertyFilter { get; set; }

        internal bool ShouldIncludeProperty(PropertyInfo property)
        {
            if (property.GetCustomAttribute<JsonIgnoreAttribute>() != null)
            {
                return false;
            }

            return PropertyFilter?.Invoke(property) ?? true;
        }
    }
}
