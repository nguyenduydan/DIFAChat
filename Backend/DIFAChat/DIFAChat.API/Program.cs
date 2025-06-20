using DIFAChat.API;
using DIFAChat.API.Hubs;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

DotEnv.Load(); // Load .env variables early

var builder = WebApplication.CreateBuilder(args);

// -------------------- Services Configuration --------------------

builder.Services.AddControllers();

// Swagger (only for Development)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DIFAChat API",
        Version = "v1"
    });
});

// SignalR for real-time communication
builder.Services.AddSignalR();

// CORS setup (adjust for production)
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultCorsPolicy", policy =>
    {
        policy.WithOrigins("https://yourfrontend.com", "http://localhost:3000") // update with your real frontend domains
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
    ?? throw new InvalidOperationException("Connection string 'DB_CONNECTION_STRING'not found.");


builder.Services.AddDbContextFactory<DifaChatDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0)),
        mySqlOptions => mySqlOptions.EnableRetryOnFailure())
    .EnableDetailedErrors(true)
    .EnableSensitiveDataLogging(false)
);



// Add other services like authentication, database, etc. here
// builder.Services.AddAuthentication(...);
// builder.Services.AddDbContext<...>();

var app = builder.Build();


// -------------------- Connect Status --------------------//
using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DifaChatDbContext>>();

    try
    {
        using var context = factory.CreateDbContext();
        var canConnect = await context.Database.CanConnectAsync();
        Console.WriteLine($"✅ Database connection: {(canConnect ? "SUCCESS" : "FAILED")}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Database connection failed: {ex.Message}");
    }
}

// -------------------- Middleware Pipeline --------------------//

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use CORS
app.UseCors("DefaultCorsPolicy");

// Add authentication/authorization if used
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chathub");

app.Run();
