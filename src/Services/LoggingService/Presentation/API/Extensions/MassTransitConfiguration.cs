using API.Consumers;
using RabbitMQ.Client;
using Constants = Application.Commands.Common.Constants.Constants;

namespace API.Extensions
{
    public static class MassTransitConfiguration
    {
        #region Public Methods

        public static IServiceCollection ConfigureMassTransit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(mt =>
            {
                mt.AddConsumer<SystemSettingLogConsumer>();
                mt.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration[Constants.RABBIT_MQ_HOST], configuration[Constants.RABBIT_MQ_VIRTUAL_HOST], h =>
                    {
                        h.Username(configuration[Constants.RABBIT_MQ_USER_NAME]);
                        h.Password(configuration[Constants.RABBIT_MQ_PASSWORD]);
                    });

                    cfg.ConfigureEndpoints(context);
                    cfg.ReceiveEndpoint(Constants.OPERATOR_QUEUE, re =>
                    {
                        re.ConfigureConsumeTopology = false;
                        re.SetQuorumQueue();
                        re.SetQueueArgument("declare", Constants.QUEUE_TYPE);
                        re.Consumer<SystemSettingLogConsumer>(services.BuildServiceProvider());
                        re.Bind(Constants.LOG_EXCHANGE, e =>
                        {
                            e.RoutingKey = Constants.OPERATOR_LOG_ROUTING_KEY;
                            e.ExchangeType = ExchangeType.Topic;
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