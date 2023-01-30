using Application.Commands.Features.Administrator;
using EventBus.Logging.Operator;

namespace API.Consumers;

public class SystemSettingLogConsumer : IConsumer<IMessage<OperatorLogRequest>>
{
    #region Private Fields

    private readonly IMediator _mediator;

    #endregion Private Fields

    #region Public Constructors

    public SystemSettingLogConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task Consume(ConsumeContext<IMessage<OperatorLogRequest>> context)
    {
        SystemSettingLogRequest request = new SystemSettingLogRequest() { OperatorLogRequest = context.Message.Data };
        await _mediator.Send(request);
    }

    #endregion Public Methods
}