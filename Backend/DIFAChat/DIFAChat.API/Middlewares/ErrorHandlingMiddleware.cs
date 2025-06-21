using DIFAChat.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace DIFAChat.API.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Chuyển tiếp middleware
            }
            catch (AppException ex)
            {
                _logger.LogWarning(ex, "⚠️ Application error");

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.StatusCode;

                var response = new
                {
                    status = ex.StatusCode,
                    message = ex.Message
                };

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                await context.Response.WriteAsync(JsonSerializer.Serialize(response, options));
            }
        }
    }
}
