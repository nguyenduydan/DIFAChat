using DIFAChat.API.Hubs;
using DIFAChat.API.Middlewares;

namespace DIFAChat.API.Extensions
{
    public class MiddlewareConfiguration
    {
        public static void Configure(WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();

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
    }
}
