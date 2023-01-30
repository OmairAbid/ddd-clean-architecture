using Application.Queries.Features.Connectors.Get;
using Domain.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connector = Domain.QueryEntities.Connector;

namespace Application.Queries.Contracts.Repositories;
public interface IConnectorQueryRepository
{
    Task<IList<Connector>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IList<ConnectionProvider>> GetAllProvidersAsync(CancellationToken cancellationToken = default);
    Task<ConnectionProvider> GetProviderAsync(string providerName, CancellationToken cancellationToken = default);
    Task<IList<Connector>> GetNamesForGlobalSettingsAsync(CancellationToken cancellationToken = default);
}
