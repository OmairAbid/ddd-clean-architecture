namespace Web.Admin.GW.Middlewares
{
	public class RemoveHeadersMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly List<string> _headersToRemove;

		public RemoveHeadersMiddleware(RequestDelegate next, List<string> headersToRemove)
		{
			_next = next;
			_headersToRemove = headersToRemove;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			httpContext.Response.OnStarting(() =>
			{
				_headersToRemove.ForEach(header =>
				{
					if (httpContext.Response.Headers.ContainsKey(header))
					{
						httpContext.Response.Headers.Remove(header);
					}
				});

				return Task.FromResult(0);
			});

			await _next.Invoke(httpContext);
		}
	}
}