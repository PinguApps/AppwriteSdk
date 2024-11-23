using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using PinguApps.Appwrite.Shared.Converters;
using PinguApps.Appwrite.Shared.Responses;
using PinguApps.Appwrite.Shared.Responses.Interfaces;
using Attribute = PinguApps.Appwrite.Shared.Responses.Attribute;

namespace PinguApps.Appwrite.Playground;
internal class App
{
    private readonly Client.IAppwriteClient _client;
    private readonly Server.Clients.IAppwriteClient _server;
    private readonly string? _session;

    public App(Client.IAppwriteClient client, Server.Clients.IAppwriteClient server, IConfiguration config)
    {
        _client = client;
        _server = server;
        _session = config.GetValue<string>("Session");
    }

    public async Task Run(string[] args)
    {
        var attributes = new List<Attribute>
        {
            new AttributeBoolean("a", "boolean", Shared.Enums.DatabaseElementStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, null),
            new AttributeDatetime("b", "datetime", Shared.Enums.DatabaseElementStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, "datetime", null),
            new AttributeEmail("c", "string", Shared.Enums.DatabaseElementStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, "email", null),
            new AttributeEnum("d", "string", Shared.Enums.DatabaseElementStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, ["some", "elements"], "enum", null),
            new AttributeFloat("e", "float", Shared.Enums.DatabaseElementStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, null, null, null),
            new AttributeInteger("f", "integer", Shared.Enums.DatabaseElementStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, null, null, null),
            new AttributeIp("g", "string", Shared.Enums.DatabaseElementStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, "ip", null),
            new AttributeRelationship("h", "string", Shared.Enums.DatabaseElementStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, "collection", Shared.Enums.RelationType.OneToMany, false, "a string", Shared.Enums.OnDelete.Restrict, Shared.Enums.RelationshipSide.Parent),
            new AttributeString("i", "string", Shared.Enums.DatabaseElementStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, 128, null),
            new AttributeUrl("j", "string", Shared.Enums.DatabaseElementStatus.Available, null, false, false, DateTime.UtcNow, DateTime.UtcNow, "url", null)
        };

        var visitor = new AttributeVisitor();

        foreach (var attribute in attributes)
        {
            attribute.Accept(visitor);
        }

        var options = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        options.Converters.Add(new IgnoreSdkExcludedPropertiesConverterFactory());

        var json = JsonSerializer.Serialize(attributes[0]);

        Console.WriteLine(json);
    }
}

internal class AttributeVisitor : IAttributeVisitor
{
    public void Visit(AttributeBoolean attribute) => Console.WriteLine($"Boolean attribute Key: {attribute.Key}");
    public void Visit(AttributeInteger attribute) => Console.WriteLine($"Integer attribute Key: {attribute.Key}");
    public void Visit(AttributeFloat attribute) => Console.WriteLine($"Float attribute Key: {attribute.Key}");
    public void Visit(AttributeString attribute) => Console.WriteLine($"String attribute Key: {attribute.Key}");
    public void Visit(AttributeEmail attribute) => Console.WriteLine($"Email attribute Key: {attribute.Key}");
    public void Visit(AttributeUrl attribute) => Console.WriteLine($"Url attribute Key: {attribute.Key}");
    public void Visit(AttributeIp attribute) => Console.WriteLine($"Ip attribute Key: {attribute.Key}");
    public void Visit(AttributeDatetime attribute) => Console.WriteLine($"Datetime attribute Key: {attribute.Key}");
    public void Visit(AttributeEnum attribute) => Console.WriteLine($"Enum attribute Key: {attribute.Key}");
    public void Visit(AttributeRelationship attribute) => Console.WriteLine($"Relationship attribute Key: {attribute.Key}");
}
