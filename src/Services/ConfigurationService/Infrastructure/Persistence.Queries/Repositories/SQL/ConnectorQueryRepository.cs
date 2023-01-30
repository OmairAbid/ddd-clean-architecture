using Application.Queries.Common.Enumerations;
using Application.Queries.Common.Helpers;
using Application.Queries.Common.Models;
using Application.Queries.Contracts.Common;
using Application.Queries.Features.Connectors.Get;
using DapperExtensions;
using Domain.QueryEntities;
using ConnectionProviderDetail = Domain.QueryEntities.ConnectionProviderDetail;
using ConnectionProviderParameter = Domain.QueryEntities.ConnectionProviderParameter;
using Connector = Domain.QueryEntities.Connector;
using ConnectorDetail = Domain.QueryEntities.ConnectorDetail;

namespace Persistence.Queries.Repositories.SQL;

public class ConnectorQueryRepository : IConnectorQueryRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public ConnectorQueryRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IList<Connector>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<Connector> _connectors;
        List<ConnectorDetail> _connectorsDetails;
        string query = @"SELECT STUFF((SELECT DISTINCT ',' + Purpose FROM ConnectionProviderDetail WHERE ConnectionProviderDetail.ConnectionProviderId = CONNECTIONPROVIDER.Id FOR XML PATH ('')), 1, 1, '') as Purpose, CONNECTIONPROVIDER.IsForADSS, Connector.*  FROM Connector
                            inner join CONNECTIONPROVIDER on CONNECTIONPROVIDER.ATTRIBUTEKEY = Connector.Provider
                            WHERE Connector.Provider NOT IN ('ENTRUST_IDENTITY_GAURD','CONSENT_ID')
                            SELECT * FROM ConnectorDetail";

        using (SqlMapper.GridReader multi = await _unitOfWork.Connection.QueryMultipleAsync(query, cancellationToken))
        {
            _connectors = multi.Read<Connector>().ToList();
            _connectorsDetails = multi.Read<ConnectorDetail>().ToList();
        }

        //populate Connector Details
        foreach (Connector connector in _connectors)
        {
            connector.Purposes = connector.Purpose == null ? new List<string>() : connector.Purpose.Split(',').ToList();
            connector.ConnectorDetail = _connectorsDetails.Where(o => o.ConnectorId == connector.Name).ToList();
        }
        return _connectors;

    }
    public async Task<IList<ConnectionProvider>> GetAllProvidersAsync(CancellationToken cancellationToken = default)
    {

        string _query = @"SELECT * FROM ConnectionProvider";
        IList<ConnectionProvider> _connectionProviders;
        string _queryForChildEntities = @"Select * from ConnectionProviderParameter Where ConnectionProviderId = @ConnectionProviderId
                                       Select * from ConnectionProviderDetail Where ConnectionProviderId = @ConnectionProviderId";

        _connectionProviders = (IList<ConnectionProvider>)await _unitOfWork.Connection.QueryAsync<ConnectionProvider>(_query);

        if (_connectionProviders.IsNotNull() && _connectionProviders.Count > 0)
        {
            _connectionProviders = _connectionProviders.Where(o => o.Status == 1 && !o.AttributeKey.Equals(ConnectionType.CONSENT_ID.ToString())
                                                                && !o.AttributeKey.Equals(ConnectionType.ENTRUST_IDENTITY_GAURD.ToString()))
                                                                .OrderBy(o => o.AttributeName).ToList();
        }

        foreach (ConnectionProvider _connectionProvider in _connectionProviders)
        {
            using (SqlMapper.GridReader multi = await _unitOfWork.Connection.QueryMultipleAsync(_queryForChildEntities, new
            {
                ConnectionProviderId = _connectionProvider.Id
            }))
            {
                _connectionProvider.ConnectionProviderParameter = multi.Read<ConnectionProviderParameter>().ToList();
                _connectionProvider.ConnectionProviderDetail = multi.Read<ConnectionProviderDetail>().ToList();
            }
        }
        return _connectionProviders;
    }

    public async Task<ConnectionProvider> GetProviderAsync(string providerName, CancellationToken cancellationToken = default)
    {

        string _query = @"SELECT * FROM ConnectionProvider WHERE AttributeName = @AttributeName AND [Status] = 1 AND AttributeKey NOT IN('CONSENT_ID','ENTRUST_IDENTITY_GAURD')";
        ConnectionProvider _connectionProvider;
        string _queryForChildEntities = @"Select * from ConnectionProviderParameter Where ConnectionProviderId = @ConnectionProviderId
                                       Select * from ConnectionProviderDetail Where ConnectionProviderId = @ConnectionProviderId";

        _connectionProvider = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<ConnectionProvider>(_query, new { AttributeName = providerName });
        if(_connectionProvider == null) return null;
        using (SqlMapper.GridReader multi = await _unitOfWork.Connection.QueryMultipleAsync(_queryForChildEntities, new
        {
            ConnectionProviderId = _connectionProvider.Id
        }))
        {
            _connectionProvider.ConnectionProviderParameter = multi.Read<ConnectionProviderParameter>().ToList();
            _connectionProvider.ConnectionProviderDetail = multi.Read<ConnectionProviderDetail>().ToList();
        }

        return _connectionProvider;
    }
    public async Task<IList<Connector>> GetNamesForGlobalSettingsAsync(CancellationToken cancellationToken = default)
    {
        const string _sqlQuery = @"select Distinct Connector.Name, ConnectionProviderDetail.Purpose, ConnectionProviderDetail.Type from Connector
                                    INNER JOIN ConnectionProvider ON Connector.Provider = Connector.Provider
                                    INNER JOIN ConnectionProviderDetail ON ConnectionProvider.Id = ConnectionProviderDetail.ConnectionProviderId
                                    where Connector.Status = 1 and Connector.Provider NOT IN ('ENTRUST_IDENTITY_GAURD','CONSENT_ID') and Connector.Provider like ConnectionProvider.AttributeKey";
        return (IList<Connector>)await _unitOfWork.Connection.QueryAsync<Connector>(_sqlQuery);
    }

}