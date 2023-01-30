namespace Web.Admin.GW.Extensions
{
	public static class AppConfiguration
	{
		public static void ConfigureApp(this IHostBuilder builder)
		{
			builder
				.ConfigureAppConfiguration((hostingContext, config) =>
				{
					IHostEnvironment env = hostingContext.HostingEnvironment;
					config
						.SetBasePath(env.ContentRootPath)
						.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
						.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
						.AddJsonFile("ocelot.json", optional: true, reloadOnChange: true)
						.AddJsonFile($"ocelot.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
						.AddEnvironmentVariables();
				});
		}
	}
}