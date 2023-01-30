namespace Application.Queries.Common.Models;

public class BasicResponse<T>
{
    public T Data { get; set; }
    public int Count { get; set; }
    public List<Error> Errors { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
}

public class Error
{
    public string ErrorMessage { get; set; }
    public string PropertyName { get; set; }
}