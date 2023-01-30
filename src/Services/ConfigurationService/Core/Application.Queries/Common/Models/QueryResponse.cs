namespace Application.Queries.Common.Models;

public class QueryResponse<T>
{
	public T Data { get; set; }
	public List<Error> Errors { get; set; }

	public bool Success { get; set; }

	public QueryResponse()
	{
		Success = true;
	}

	public QueryResponse(List<Error> errors)
	{
		Success = false;
		Errors = errors;
	}

	public QueryResponse(string propertyName, string errorMessage)
	{
		Success = false;
		Errors = new()
			{
				new Error() { PropertyName = propertyName, ErrorMessage = errorMessage }
			};
	}
}

public class QueryResponse
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