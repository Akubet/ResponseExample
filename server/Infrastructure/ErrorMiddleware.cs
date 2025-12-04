using System.Text.Json;

namespace server.Infrastructure;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 500;

            var json = JsonSerializer.Serialize(
                ApiResponse<object>.Fail(
                    ErrorCodes.ServerError,
                    "Internal server error")
            );

            await context.Response.WriteAsync(json);
        }
    }
}