namespace Web.Admin.GW.Extensions
{
	public static class CorsConfiguration
	{
		public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
		{
			services.AddCors(config =>
				config.AddPolicy(PolicyNames.AllowAll,
					p => p.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader()));

			return services;
		}
	}
}