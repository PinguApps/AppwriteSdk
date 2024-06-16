using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PinguApps.Appwrite.Client;
using PinguApps.Appwrite.Playground;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddAppwriteClient(builder.Configuration.GetValue<string>("ProjectId")!);
builder.Services.AddSingleton<App>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    await services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
