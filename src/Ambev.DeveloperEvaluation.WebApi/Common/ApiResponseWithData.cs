namespace Ambev.DeveloperEvaluation.WebApi.Common;

public class ApiResponseWithData<T> : ApiResponse
{
   // public bool Success { get; set; }
   // public string Message { get; set; }
    public T? Data { get; set; }
}
