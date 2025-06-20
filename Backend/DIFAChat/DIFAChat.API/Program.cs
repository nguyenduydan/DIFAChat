using DIFAChat.API;
using DIFAChat.API.Hubs;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

// Load environment variables
DotEnv.Load();

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
if (builder.Environment.IsDevelopment())
{
    builder.Logging.SetMinimumLevel(LogLevel.Debug);
}

Console.WriteLine("🚀 Starting DIFAChat API...");

try
{
    ConfigureServices(builder.Services, builder.Configuration, builder.Environment);
    var app = builder.Build();

    await TestDatabaseConnection(app.Services);
    ConfigureMiddleware(app);

    PrintReadyMessage(app.Environment);
    await app.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Startup failed: {ex.Message}");
    Environment.Exit(1);
}

void ConfigureServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
{
    // Controllers
    services.AddControllers();

    // API Documentation
    if (environment.IsDevelopment())
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "DIFAChat API",
                Version = "v1.0.0",
                Description = "Real-time chat application API",
                Contact = new OpenApiContact
                {
                    Name = "DIFAChat Development Team"
                }
            });

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
            }
        });
    }

    // SignalR
    services.AddSignalR(options =>
    {
        options.EnableDetailedErrors = environment.IsDevelopment();
        options.KeepAliveInterval = TimeSpan.FromSeconds(15);
        options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
    });

    // CORS Policy
    services.AddCors(options =>
    {
        options.AddPolicy("DefaultCorsPolicy", policy =>
        {
            var allowedOrigins = environment.IsDevelopment()
                ? new[] { "http://localhost:3000", "http://localhost:3001", "http://localhost:5173" }
                : new[] { "https://yourfrontend.com" };

            policy.WithOrigins(allowedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
    });

    // Database Configuration
    var connectionString = GetConnectionString(configuration);
    services.AddDbContextFactory<DifaChatDbContext>(options =>
    {
        options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0)),
            mySqlOptions =>
            {
                mySqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 3,
                    maxRetryDelay: TimeSpan.FromSeconds(5),
                    errorNumbersToAdd: null);
                mySqlOptions.CommandTimeout(30);
            })
            .EnableDetailedErrors(environment.IsDevelopment())
            .EnableSensitiveDataLogging(environment.IsDevelopment());
    });

    Console.WriteLine("✅ Services configured");
}

void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "DIFAChat API v1");
            c.RoutePrefix = "swagger";
        });
    }

    app.UseHttpsRedirection();
    app.UseCors("DefaultCorsPolicy");
    app.UseAuthorization();
    app.MapControllers();
    app.MapHub<ChatHub>("/chathub");

    Console.WriteLine("✅ Middleware configured");
}

string GetConnectionString(IConfiguration configuration)
{
    var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

    if (string.IsNullOrWhiteSpace(connectionString))
    {
        connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Database connection string not found. Please set DB_CONNECTION_STRING environment variable or DefaultConnection in appsettings.json");
        }
    }

    return connectionString;
}
void PrintBanner()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine();
    Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
    Console.WriteLine("║                        DIFAChat API                          ║");
    Console.WriteLine("║                   Real-time Chat Service                     ║");
    Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
    Console.ResetColor();
    Console.WriteLine();
}
async Task TestDatabaseConnection(IServiceProvider services)
{
    using var scope = services.CreateScope();
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DifaChatDbContext>>();

    try
    {
        using var context = factory.CreateDbContext();
        var canConnect = await context.Database.CanConnectAsync();

        if (canConnect)
        {
            Console.WriteLine("✅ Database connected");
        }
        else
        {
            Console.WriteLine("❌ Database connection failed");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Database error: {ex.Message}");
        throw;
    }
}

void PrintReadyMessage(IWebHostEnvironment environment)
{
    PrintBanner();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("🎉 DIFAChat API is running!");
    Console.ResetColor();

    if (environment.IsDevelopment())
    {
        Console.WriteLine("📖 Swagger: https://localhost:7291/swagger");
    }
    Console.WriteLine("🔗 SignalR: https://localhost:7291/chathub");
    Console.WriteLine("🌐 API: https://localhost:7291/api");
    Console.WriteLine("\nPress Ctrl+C to stop...");
}