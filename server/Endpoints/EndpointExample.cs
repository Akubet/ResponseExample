using server.Infrastructure;

namespace server.Endpoints;

public static class UsersEndpoints
{
    public static IEndpointRouteBuilder MapUsers(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users/{id:int}", async (int id) =>
        {

            var errors = new List<ValidationError>();

            if (id <= 0)
                errors.Add(new("Id", "Id must be greater than zero"));
            if (errors.Any())
                return ApiResponse<object>.ValidationError(errors);

            return ApiResponse<object>.Ok(new { id, name = "John Doe" });
        });

        return app;
    }
}