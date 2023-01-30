using Application.Queries.Common.Enumerations;
using Application.Queries.Common.Models;
using Application.Queries.Contracts.Common;
using Domain.QueryEntities;
using ConnectionProviderDetail = Domain.QueryEntities.ConnectionProviderDetail;
using ConnectionProviderParameter = Domain.QueryEntities.ConnectionProviderParameter;
using Connector = Domain.QueryEntities.Connector;
using ConnectorDetail = Domain.QueryEntities.ConnectorDetail;

namespace Persistence.Queries.Repositories.ORACLE;
public class OraConnectorQueryRepository : IConnectorQueryRepository
{

    private readonly IUnitOfWork _unitOfWork;

    public OraConnectorQueryRepository(IUnitOfWork UnitOfWork)
    {
        _unitOfWork = UnitOfWork;
    }

    public async Task<IList<Connector>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Connector> connectors;
        List<ConnectorDetail> connectorsDetails;
        var queryData = await _unitOfWork.Connection.QueryAsync<Connector>("SELECT (SELECT LISTAGG(CAST(Purpose as varchar(2000)), ',') WITHIN GROUP (ORDER BY ConnectionProviderId)  FROM (SELECT DISTINCT PURPOSE , ConnectionProviderId FROM ConnectionProviderDetail WHERE ConnectionProviderDetail.ConnectionProviderId = CONNECTIONPROVIDER.Id)) as Purpose, CONNECTIONPROVIDER.ISFORADSS, Connector.*  FROM Connector JOIN CONNECTIONPROVIDER on CONNECTIONPROVIDER.ATTRIBUTEKEY = Connector.Provider WHERE Connector.Provider NOT IN ('ENTRUST_IDENTITY_GAURD','CONSENT_ID')");
        connectors = queryData.ToList();
        connectorsDetails = _unitOfWork.Connection.Query<ConnectorDetail>("SELECT * FROM CONNECTORDETAIL").ToList();

        foreach (Connector connector in connectors)
        {
            connector.Purposes = connector.Purpose == null ? new List<string>() : connector.Purpose.Split(',').ToList();
            connector.ConnectorDetail = connectorsDetails.Where(o => o.ConnectorId == connector.Name).ToList();
        }
        return connectors;
    }
    public async Task<IList<ConnectionProvider>> GetAllProvidersAsync(CancellationToken cancellationToken = default)
    {
        IList<ConnectionProvider> _connectionProviders;
        string _queryForChildEntities = @"SELECT * FROM CONNECTIONPROVIDERPARAMETER WHERE CONNECTIONPROVIDERID = :ConnectionProviderId";
        string _queryForChildEntities2 = @"SELECT * FROM CONNECTIONPROVIDERDETAIL WHERE CONNECTIONPROVIDERID = :ConnectionProviderId";

        _connectionProviders = (IList<ConnectionProvider>) await _unitOfWork.Connection.QueryAsync<ConnectionProvider>("SELECT * FROM CONNECTIONPROVIDER");

        if (_connectionProviders.Count > 0)
        {
            _connectionProviders = _connectionProviders.Where(o => o.Status == 1 && !o.AttributeKey.Equals(ConnectionType.CONSENT_ID.ToString())
                                                        && !o.AttributeKey.Equals(ConnectionType.ENTRUST_IDENTITY_GAURD.ToString()))
                                                        .OrderBy(o => o.AttributeName).ToList();
        }
        foreach (ConnectionProvider _connectionProvider in _connectionProviders)
        {
            _connectionProvider.ConnectionProviderParameter = _unitOfWork.Connection.Query<ConnectionProviderParameter>(_queryForChildEntities, new { ConnectionProviderId = _connectionProvider.Id }).ToList();
            _connectionProvider.ConnectionProviderDetail = _unitOfWork.Connection.Query<ConnectionProviderDetail>(_queryForChildEntities2, new { ConnectionProviderId = _connectionProvider.Id }).ToList();
        }
        return _connectionProviders;
    }

    public async Task<IList<Connector>> GetNamesForGlobalSettingsAsync(CancellationToken cancellationToken = default)
    {
        const string _oraQuery = @"SELECT DISTINCT CONNECTOR.NAME, CONNECTIONPROVIDERDETAIL.PURPOSE, CONNECTIONPROVIDERDETAIL.TYPE FROM CONNECTOR
                                    INNER JOIN CONNECTIONPROVIDER ON CONNECTOR.PROVIDER = CONNECTOR.PROVIDER
                                    INNER JOIN CONNECTIONPROVIDERDETAIL ON CONNECTIONPROVIDER.ID = CONNECTIONPROVIDERDETAIL.CONNECTIONPROVIDERID
                                    WHERE CONNECTOR.STATUS = 1 AND CONNECTOR.PROVIDER NOT IN ('ENTRUST_IDENTITY_GAURD','CONSENT_ID') AND CONNECTOR.PROVIDER LIKE CONNECTIONPROVIDER.ATTRIBUTEKEY";
        return (IList<Connector>)await _unitOfWork.Connection.QueryAsync<Connector>(_oraQuery);
    }

    public async Task<ConnectionProvider> GetProviderAsync(string providerName, CancellationToken cancellationToken = default)
    {
        ConnectionProvider _connectionProvider;
        string _queryForParentEntities = @"SELECT * FROM CONNECTIONPROVIDER WHERE ATTRIBUTENAME = @AttributeName AND [STATUS] = 1 AND ATTRIBUTEKEY NOT IN('CONSENT_ID','ENTRUST_IDENTITY_GAURD')";
        string _queryForChildEntities = @"SELECT * FROM CONNECTIONPROVIDERPARAMETER WHERE CONNECTIONPROVIDERID = :ConnectionProviderId";
        string _queryForChildEntities2 = @"SELECT * FROM CONNECTIONPROVIDERDETAIL WHERE CONNECTIONPROVIDERID = :ConnectionProviderId";

        _connectionProvider = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ConnectionProvider>(_queryForParentEntities, new { AttributeName = providerName });

        if (_connectionProvider == null) return null;

        _connectionProvider.ConnectionProviderParameter = (List<ConnectionProviderParameter>)await _unitOfWork.Connection.QueryAsync<ConnectionProviderParameter>(_queryForChildEntities, new { ConnectionProviderId = _connectionProvider.Id });
        _connectionProvider.ConnectionProviderDetail = (List<ConnectionProviderDetail>)await _unitOfWork.Connection.QueryAsync<ConnectionProviderDetail>(_queryForChildEntities2, new { ConnectionProviderId = _connectionProvider.Id });

        return _connectionProvider;
    }
}