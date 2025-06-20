using Microsoft.EntityFrameworkCore;

namespace DIFAChat.API.Extensions
{
    public class StartupUtilities
    {
        public static async Task TestDatabaseConnectionAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<DifaChatDbContext>>();

            try
            {
                using var context = factory.CreateDbContext();
                var canConnect = await context.Database.CanConnectAsync();

                Console.WriteLine(canConnect ? "✅ Database connected" : "❌ Database connection failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Database error: {ex.Message}");
                throw;
            }
        }

        public static void PrintStartupInfo(IWebHostEnvironment env)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                        DIFAChat API                          ║");
            Console.WriteLine("║                   Real-time Chat Service                     ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("🎉 DIFAChat API is running!");
            Console.ResetColor();

            if (env.IsDevelopment())
            {
                Console.WriteLine("📖 Swagger: https://localhost:7291/swagger");
            }
            Console.WriteLine("🔗 SignalR: https://localhost:7291/chathub");
            Console.WriteLine("🌐 API: https://localhost:7291/api");
            Console.WriteLine("\nPress Ctrl+C to stop...");
        }
    }
}
