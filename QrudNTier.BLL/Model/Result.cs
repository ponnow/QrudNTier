
using QrudNTier.Model;
using System.Collections;

namespace QrudNTier.BLL.Model;

public class Result<T>
{
    public bool Success { get; set; }
    public string Error { get; set; } = string.Empty;
    public T? Data { get; set; }
    public Result(bool Success, T? data, string? error)
    {
        Success = Success;
        Data = data;
        Error = error;
    }
    public static Result<T> SuccessResult(T data)
    {
        return new Result<T>(true, data, string.Empty);
    }
    public static Result<T> FailureResult(string error)
    {
        return new Result<T>(false, default, error);
    }

    internal static Result<IList<Product>> SuccessResult(IList products)
    {
        throw new NotImplementedException();
    }
}
