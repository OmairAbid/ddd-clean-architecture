

namespace Web.Admin.GW.Extensions
{
	public static class OcelotConfiguration
	{
		public static IServiceCollection AddGateway(this IServiceCollection services)
		{
			services.AddOcelot();

			return services;
		}

		public static async Task<IApplicationBuilder> UseGateway(this IApplicationBuilder app)
		{
			await app.UseOcelot();

			return app;
		}
	}
}