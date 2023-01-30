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

        //TODO : Add Role Check to make sure user has rights to Update the Connector.
        //TODO : Pre Request data Validation

        //TODO : Disucss and remove additional things from command model

        BasicResponse<Connector> response = new();
        Connector _connector;
        ConnectorDetail _connectorDetail;
        _connector = new Connector
        {
            Status = request.Status ? (int)Status.ENABLED : (int)Status.DISABLED,
            Name = request.ConnectorName,
            //IsForADSS = request.IsForADSS == 1,
            Provider = request.ProviderParams.AttributeKey,
            Identifier = request.ProviderParams.AttributeName,
            HMAC = request.ProviderParams.HMAC ?? DatabaseStaticData.HMAC,
            CreatedBy = request.UserEmail ?? request.ProviderParams.CreatedBy ?? DatabaseStaticData.ADMIN,
            LastModifiedBy = request.UserEmail ?? request.ProviderParams.LastModifiedBy ?? DatabaseStaticData.ADMIN,
            LastModifiedOn = request.ProviderParams.LastModifiedOn ?? DateTime.Now,
            ConnectorDetail = new List<ConnectorDetail>(),

        };
        request.ProviderParams.ConnectionProviderParameter.ForEach((item) =>
        {
            _connectorDetail = new ConnectorDetail
            {
                ConnectorId = _connector.Name,
                AttributeName = item.AttributeKey,
                AttributeValue = item.AttributeValue != null ? item.AttributeValue.Trim() : string.Empty,
                //SortOrder = item.SortOrder,
                Type = item.Type,
                CreatedBy = request.UserEmail ?? item.CreatedBy ?? DatabaseStaticData.ADMIN,
                LastModifiedBy = request.UserEmail ?? item.LastModifiedBy ?? DatabaseStaticData.ADMIN,
                LastModifiedOn = item.LastModifiedOn ?? DateTime.Now,
                HMAC = item.HMAC ?? DatabaseStaticData.HMAC,
            };

            _connector.ConnectorDetail.Add(_connectorDetail);
        });

        await _connectorCommandRepository.UpdateWithRelationAsync(_connector);

        if (await _unitOfWork.CommitAsync(cancellationToken))
        {
            response.Success = true;
        }

        return new BasicResponse(){ Success = true};
    }

    #endregion
}
