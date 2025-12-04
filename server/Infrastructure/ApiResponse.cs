using System.Text.Json.Serialization;

namespace server.Infrastructure;

public class ApiResponse<T>
{
    public bool Success { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorCodes? ErrorCode { get; set; }

    public string? Message { get; set; }

    public T? Data { get; set; }

    public List<ValidationError>? ValidationErrors { get; set; }

    public static ApiResponse<T> Ok(T data, string? message = null) =>
        new() { Success = true, Data = data, Message = message };

    public static ApiResponse<T> Fail(ErrorCodes code, string? message = null) =>
        new() { Success = false, ErrorCode = code, Message = message };

    public static ApiResponse<T> ValidationError(List<ValidationError> errors) =>
    new()
    {
        Success = false,
        ErrorCode = ErrorCodes.ValidationError,
        Message = "Validation failed",
        ValidationErrors = errors
    };
}