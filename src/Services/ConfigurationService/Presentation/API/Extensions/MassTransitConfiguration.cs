using RabbitMQ.Client;

namespace API.Extensions
{
    public static class MassTransitConfiguration
    {
        #region Public Methods

        public static IServiceCollection AddMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(mt =>
            {
                mt.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration["RabbitMQ:Host"], configuration["RabbitMQ:VirtualHost"], h =>
                    {
                        h.Username(configuration["RabbitMQ:UserName"]);
                        h.Password(configuration["RabbitMQ:Password"]);
                    });

                    cfg.Message<IMessage>(e => e.SetEntityName("Log_Exchange")); //Set Exchange name
                    cfg.Publish<IMessage>(e => e.ExchangeType = ExchangeType.Topic); // primary exchange type
                    cfg.Send<IMessage>(e =>
                    {
                        e.UseRoutingKeyFormatter(context =>
                        {
                            return $"{context.Message.Reciever}."; //Routing
                        });
                    });
                });
            });

            services.AddOptions<MassTransitHostOptions>().Configure(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(10);
                options.StopTimeout = TimeSpan.FromSeconds(30);
            });

            return services;
        }

        #endregion Public Methods
    }
}