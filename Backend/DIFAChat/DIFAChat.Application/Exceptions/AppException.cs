using System;

namespace DIFAChat.Application.Exceptions
{
    /// <summary>
    /// Base application exception with support for HTTP status code.
    /// </summary>
    public class AppException : Exception
    {
        public int StatusCode { get; }

        public AppException(string message, int statusCode = 400)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public AppException(string message, Exception inner, int statusCode = 400)
            : base(message, inner)
        {
            StatusCode = statusCode;
        }
    }

    /// <summary>
    /// Exception for not found resources (404).
    /// </summary>
    public class NotFoundException : AppException
    {
        public NotFoundException(string message = "Resource not found")
            : base(message, 404) { }
    }

    /// <summary>
    /// Exception for unauthorized access (401).
    /// </summary>
    public class UnauthorizedException : AppException
    {
        public UnauthorizedException(string message = "Unauthorized access")
            : base(message, 401) { }
    }

    /// <summary>
    /// Exception for forbidden actions (403).
    /// </summary>
    public class ForbiddenException : AppException
    {
        public ForbiddenException(string message = "Access denied")
            : base(message, 403) { }
    }

    /// <summary>
    /// Exception for validation failures (400).
    /// </summary>
    public class ValidationException : AppException
    {
        public ValidationException(string message = "Validation failed")
            : base(message, 400) { }
    }
}
