namespace TastyPoint.API.Shared.Domain.Services.Communication;

public class BaseResponse<T>
{
    public T Resource { get; private set; }
    public bool Success { get; private set; }
    public string Message { get; private set; }
    

    protected BaseResponse(T resource)
    {
        Success = true;
        Resource = resource;
        Message = string.Empty;
    }

    protected BaseResponse(string message)
    {
        Success = false;
        Resource = default;
        Message = message;
    }
}