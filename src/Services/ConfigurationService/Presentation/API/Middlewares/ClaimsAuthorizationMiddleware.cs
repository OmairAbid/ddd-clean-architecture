using API.Model;

namespace API.Middlewares;

public class ClaimsAuthorizationMiddleware
{
	#region Private Fields

	private readonly RequestDelegate _next;

	#endregion Private Fields

	#region Public Constructors

	public ClaimsAuthorizationMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	#endregion Public Constructors

	#region Public Methods

	public async Task InvokeAsync(HttpContext context, LoggedInUser user)
	{
		if (IsLoggedInUserUpdated(context, user))
		{
			await _next(context);
		}
		else
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
			await context.Response.WriteAsync("Access denied!");
			return;
		}
	}

	#endregion Public Methods

	#region Private Methods

	private static bool IsLoggedInUserUpdated(HttpContext httpContext, LoggedInUser loggedinUser)
	{
		string userRole = httpContext.Request.Headers["UserRole"];
		string userEmail = httpContext.Request.Headers["UserEmail"];
		if (userRole == null || userEmail == null)
		{
			return false;
		}

		loggedinUser.EmailAddress = userEmail;
		loggedinUser.RoleId = Convert.ToInt32(userRole);

		return true;
	}

	#endregion Private Methods
}