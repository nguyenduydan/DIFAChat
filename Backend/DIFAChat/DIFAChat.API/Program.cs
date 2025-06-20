using DIFAChat.API;
using DIFAChat.API.Extensions;
using dotenv.net;

DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
if (builder.Environment.IsDevelopment())
    builder.Logging.SetMinimumLevel(LogLevel.Debug);

Console.WriteLine("🚀 Starting DIFAChat API...");

try
{
    ServiceConfiguration.Configure(builder.Services, builder.Configuration, builder.Environment);

    var app = builder.Build();

    await StartupUtilities.TestDatabaseConnectionAsync(app.Services);

    MiddlewareConfiguration.Configure(app);

    StartupUtilities.PrintStartupInfo(app.Environment);

    await app.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Startup failed: {ex.Message}");
    Environment.Exit(1);
}
