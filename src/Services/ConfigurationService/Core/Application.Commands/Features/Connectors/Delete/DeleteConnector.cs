using Application.Commands.Common.Enumerations;
using Application.Commands.Features.Connectors.Add;

namespace Application.Commands.Features.Connectors.Delete;
public class DeleteConnectorRequest: IRequest<BasicResponse>
{
    #region Public Properties

    public string ConnectorName { get; set; }
    public string UserEmail { get; set; }

    #endregion Public Properties
}


public class DeleteConnectorRequestHandler : IRequestHandler<DeleteConnectorRequest, BasicResponse>
{
    #region Private Fields

    private readonly IConnectorCommandRepository _connectorCommandRepository;
    private readonly IUnitOfWork _unitOfWork;

    #endregion Private Fields

    #region Public Constructors

    public DeleteConnectorRequestHandler(IConnectorCommandRepository connectorCommandRepository,
        IUnitOfWork unitOfWork
        )
    {
        _connectorCommandRepository = connectorCommandRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<BasicResponse> Handle(DeleteConnectorRequest request, CancellationToken cancellationToken)
    {

        //TODO : Add Role Check to make sure user has rights to Delete the Connector.
        //TODO : Check ActionAllowedOnConnector
        //TODO : Add BO 

        await _connectorCommandRepository.DeleteByNameAsync(request.ConnectorName, cancellationToken);
        bool response = await _unitOfWork.CommitAsync(cancellationToken);
        return new BasicResponse() { Success = response };
    }

    #endregion
}
