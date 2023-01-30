namespace Web.Admin.GW.Middlewares
{
	public class ResponseHeadersMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly List<KeyValuePair<string, string>> _headersToAdd;

		public ResponseHeadersMiddleware(RequestDelegate next, List<KeyValuePair<string, string>> headersToAdd)
		{
			_next = next;
			_headersToAdd = headersToAdd;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			httpContext.Response.OnStarting(() =>
			{
				_headersToAdd.ForEach(header =>
				{
					if (!httpContext.Response.Headers.ContainsKey(header.Key))
					{
						httpContext.Response.Headers.Add(header.Key, header.Value);
					}
				});

				return Task.FromResult(0);
			});

			await _next.Invoke(httpContext);
		}
	}
}