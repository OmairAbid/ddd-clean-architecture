

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

        //TODO : Add Role Check to make sure user has rights to Add the Connector.
        //TODO : Pre Request data Validation

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
                
                AttributeName = item.AttributeKey,
                AttributeValue = item.AttributeValue != null ? item.AttributeValue.Trim() : string.Empty,
                //SortOrder = item.SortOrder,
                Type = item.Type,
                CreatedBy = request.UserEmail?? item.CreatedBy?? DatabaseStaticData.ADMIN,
                LastModifiedBy = request.UserEmail?? item.LastModifiedBy?? DatabaseStaticData.ADMIN,
                LastModifiedOn = item.LastModifiedOn ?? DateTime.Now,
                HMAC = item.HMAC ?? DatabaseStaticData.HMAC,
            };

            _connector.ConnectorDetail.Add(_connectorDetail);
        });

       Connector connector = await _connectorCommandRepository.AddAsync(_connector);

        if (await _unitOfWork.CommitAsync(cancellationToken))
        {
            response.Data = connector;
            response.Success = true;
        }

        response.Data = _connector.DeepClone();
        response.Success = true;
        
        return response;
    }

    #endregion
}
