using Microsoft.AspNetCore.Authorization;
using server.Endpoints;
using server.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, ApiAuthorizationHandler>();

var app = builder.Build();

app.UseMiddleware<ErrorMiddleware>();


TsGenerator.MapTsEndpoints(app);

app.Use(async (context, next) =>
{
    await next();

    if (context.Request.Path.StartsWithSegments("/api") &&
        context.Response.StatusCode == 404 &&
        !context.Response.HasStarted)
    {
        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(
            ApiResponse<object>.Fail(ErrorCodes.NotFound, "API endpoint not found")
        );
    }
});

app.MapUsers();

app.Run();
