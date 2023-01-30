namespace API.Model;

public class FailureResponse
{
    public bool Success { get; set; }

    public string Message { get; set; }
    public List<Error> Errors { get; set; }

    public string Exception { get; set; }
}
public class JsonErrorResponse
{
    public string[] Messages { get; set; }

    public object DeveloperMessage { get; set; }
}

public class Error
{
    public string ErrorMessage { get; set; }
    public string PropertyName { get; set; }
}