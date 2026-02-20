using Microsoft.VisualBasic;

namespace Projeto_Credito_Cliente.Utils;

public class ServiceResult<T>
{
    public T Object { get; set; }

    public string Message { get; set; }

    public bool Success { get; set; }

    public static ServiceResult<T> Ok(T obj, string message = null)
    {
        return new()
        {
            Object = obj,
            Message = message,
            Success = true,
        };
    }

    public static ServiceResult<T> Fail(string message = null)
    {
        return new()
        {
            Message = message,
            Success = false,
        };
    }


}