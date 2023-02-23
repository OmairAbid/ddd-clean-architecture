using Application.Commands.Common.Enumerations;
using Application.Commands.Features.Connectors.Add;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Commands.Common.Constants.Constants;

namespace Application.Commands.Features.Connectors.Update;
public class UpdateConnectorRequest : IRequest<BasicResponse>
{
    #region Public Properties
    public string ConnectorName { get; set; }
    public string UserEmail { get; set; }

    public bool Status { get; set; }

    public ConnectionProvider ProviderParams { get; set; }

    #endregion Public Properties
}

public class UpdateConnectorRequestHandler : IRequestHandler<UpdateConnectorRequest, BasicResponse>
{
    #region Private Fields

    private readonly IConnectorCommandRepository _connectorCommandRepository;
    private readonly IUnitOfWork _unitOfWork;

    #endregion Private Fields

    #region Public Constructors

    public UpdateConnectorRequestHandler(IConnectorCommandRepository connectorCommandRepository,
        IUnitOfWork unitOfWork
        )
    {
        _connectorCommandRepository = connectorCommandRepository;
        _unitOfWork = unitOfWork;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<BasicResponse> Handle(UpdateConnectorRequest request, CancellationToken cancellationToken)
    {

        

        BasicResponse<Connector> response = new();

        if (await _unitOfWork.CommitAsync(cancellationToken))
        {
            response.Success = true;
        }

        return new BasicResponse(){ Success = true};
    }

    #endregion
}
