using Application.Commands.Common.Models;

public class EventConsumer : IConsumer<IMessage>
{
    public async Task Consume(ConsumeContext<IMessage> context)
    {
        //TODO: Logging here

        //await context.Publish<ILogAdded>(new
        //{
        //    context.Message.Id
        //});
    }
}