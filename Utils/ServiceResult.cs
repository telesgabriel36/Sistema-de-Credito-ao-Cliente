using Microsoft.VisualBasic;

namespace Projeto_Credito_Cliente.Utils;

public class ServiceResult<T>
{
    public T Object { get; set; }

    public string Message { get; set; }

    public bool Result { get; set; }

    public static ServiceResult<T> Success(T obj, string message = null)
    {
        return new()
        {
            Object = obj,
            Message = message,
            Result = true,
        };
    }

    public static ServiceResult<T> Fail(string message = null)
    {
        return new()
        {
            Message = message,
            Result = false,
        };
    }


}