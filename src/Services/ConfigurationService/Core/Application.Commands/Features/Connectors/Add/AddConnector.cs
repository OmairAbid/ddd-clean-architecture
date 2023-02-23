

using Application.Commands.Common.Enumerations;
using Application.Commands.Contracts.Common;
using Domain.Common;
using MassTransit;
using static Application.Commands.Common.Constants.Constants;

namespace Application.Commands.Features.Connectors.Add;

public class AddConnectorRequest : IRequest<BasicResponse<Connector>>
{
    #region Public Properties
    public string ConnectorName { get; set; }
    public string UserEmail { get; set; }

    public bool Status { get; set; }

    public ConnectionProvider ProviderParams { get; set; }

    #endregion Public Properties
}
public class AddConnectorRequestHandler : IRequestHandler<AddConnectorRequest, BasicResponse<Connector>>
{
    #region Private Fields

    private readonly IConnectorCommandRepository _connectorCommandRepository;
    private readonly IUnitOfWork _unitOfWork;

    #endregion Private Fields

    #region Public Constructors

    public AddConnectorRequestHandler(IConnectorCommandRepository connectorCommandRepository,
        IUnitOfWork unitOfWork
        )
    {
        _connectorCommandRepository = connectorCommandRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<BasicResponse<Connector>> Handle(AddConnectorRequest request, CancellationToken cancellationToken)
    {

        BasicResponse<Connector> response = new();
        
        if (await _unitOfWork.CommitAsync(cancellationToken))
        {
            response.Data = connector;
            response.Success = true;
        }

        response.Success = true;
        
        return response;
    }

    #endregion
}
