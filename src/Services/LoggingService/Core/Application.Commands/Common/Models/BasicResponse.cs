namespace Application.Commands.Common.Models;

public class BasicResponse<T>
{
    public T Data { get; set; }
    public List<Error> Errors { get; set; }

    public string? Message { get; set; }
    public bool Success { get; set; }
}

public class BasicResponse
{
    public bool Success { get; set; }

    public string? Message { get; set; }
    public List<Error> Errors { get; set; }
}

public class Error
{
    public string ErrorMessage { get; set; }
    public string PropertyName { get; set; }
}