using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PinguApps.Appwrite.Client;
using PinguApps.Appwrite.Playground;
using PinguApps.Appwrite.Realtime;
using PinguApps.Appwrite.Server;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddAppwriteClient(builder.Configuration.GetValue<string>("ProjectId")!);
//builder.Services.AddAppwriteClientForServer(builder.Configuration.GetValue<string>("ProjectId")!);
builder.Services.AddAppwriteServer(builder.Configuration.GetValue<string>("ProjectId")!, builder.Configuration.GetValue<string>("ApiKey")!);
builder.Services.AddAppwriteRealtime(builder.Configuration.GetValue<string>("ProjectId")!);
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
