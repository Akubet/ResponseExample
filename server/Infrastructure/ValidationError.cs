namespace server.Infrastructure;

public class ValidationError
{
    public ValidationError(string field, string message)
    {
        Field = field;
        Message = message;
    }

    public ValidationError()
    {
    }

    public string Field { get; set; } = default!;
    public string Message { get; set; } = default!;
}