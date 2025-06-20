using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using DIFAChat.Infrastructure.Configuration;

namespace DIFAChat.API.Extensions
{
    public class ServiceConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            services.AddControllers();

            if (environment.IsDevelopment())
            {
                {
                    services.AddEndpointsApiExplorer();
                    services.AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Title = "DIFAChat API",
                            Version = "v1.0.0",
                            Description = "Real-time chat application API",
                            Contact = new OpenApiContact { Name = "DIFAChat Development Team" }
                        });

                        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                        if (File.Exists(xmlPath))
                            options.IncludeXmlComments(xmlPath);
                    });
                }
            }
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = environment.IsDevelopment();
                options.KeepAliveInterval = TimeSpan.FromSeconds(15);
                options.ClientTimeoutInterval = TimeSpan.FromSeconds(30);
            });

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

            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                                  ?? configuration.GetConnectionString("DefaultConnection")
                                  ?? throw new InvalidOperationException("Database connection string not found.");

            services.AddDbContextFactory<DifaChatDbContext>(options =>
            {
                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 0)), mysql =>
                {
                    mysql.EnableRetryOnFailure(3, TimeSpan.FromSeconds(5), null);
                    mysql.CommandTimeout(30);
                })
                .EnableDetailedErrors(environment.IsDevelopment())
                .EnableSensitiveDataLogging(environment.IsDevelopment());
            });

            // Repositories & Services
            services.AddInfrastructure();


            Console.WriteLine("✅ Services configured");
        }
    }
}
