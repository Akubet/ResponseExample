using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace server.Infrastructure;

public class ApiAuthorizationHandler : IAuthorizationMiddlewareResultHandler
{
    private readonly AuthorizationMiddlewareResultHandler _default = new();

    public async Task HandleAsync(
        RequestDelegate next,
        HttpContext context,
        AuthorizationPolicy policy,
        PolicyAuthorizationResult result)
    {
        if (result.Challenged)
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsJsonAsync(
                ApiResponse<object>.Fail(ErrorCodes.Unauthorized, "Authentication required"));
            return;
        }

        if (result.Forbidden)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsJsonAsync(
                ApiResponse<object>.Fail(ErrorCodes.Forbidden, "Access denied"));
            return;
        }

        await _default.HandleAsync(next, context, policy, result);
    }
}