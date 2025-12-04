namespace server.Infrastructure;

public static class TsGenerator
{
    public static void MapTsEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/ts/error-codes.ts", () =>
        {
            var names = Enum.GetNames(typeof(ErrorCodes));
            var lines = names.Select(n => $"  | \"{n}\"").ToList();
            lines[0] = lines[0].Replace("|", "");
            var ts = "export type ErrorCode =\n" + string.Join("\n", lines) + ";\n";

            return Results.Text(ts, "text/plain");
        });
    }
}