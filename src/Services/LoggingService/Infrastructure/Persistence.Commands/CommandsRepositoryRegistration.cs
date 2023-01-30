namespace Persistence.Commands
{
    public static class CommandsRepositoryRegistration
    {
        #region Public Methods

        public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdministratorLogCommandDbContext>(options =>
            {
                if (configuration.GetConnectionString("DBProvider").ToUpper() == "SQL")
                {
                    options.UseSqlServer(configuration.GetConnectionString("DBConnectiongString"), sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                    });
                }
                else
                {
                    options.UseOracle(configuration.GetConnectionString("DBConnectiongString"));
                }
            });
        }

        public static IServiceCollection AddPersistentCommandServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            services.AddTransient<IAdministratorLogRepository, AdministratorLogRepository>();
            services.AddTransient<IServiceplanRepository, ServiceplanRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            return services;
        }

        #endregion Public Methods
    }
}