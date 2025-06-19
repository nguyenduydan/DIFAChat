using DIFAChat.API.Hubs;
using dotenv.net;
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

// Add other services like authentication, database, etc. here
// builder.Services.AddAuthentication(...);
// builder.Services.AddDbContext<...>();

var app = builder.Build();

// -------------------- Middleware Pipeline --------------------

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
