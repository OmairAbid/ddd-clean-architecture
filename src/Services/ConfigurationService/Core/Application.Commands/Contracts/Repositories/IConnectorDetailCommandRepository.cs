using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Contracts.Repositories;
public interface IConnectorDetailCommandRepository: IAsyncCommandRepository<ConnectorDetail>
{
    Task<bool> BulkInsertAsync(ICollection<ConnectorDetail> connectorDetails, CancellationToken cancellationToken = default);
    Task<bool> BulkUpdateAsync(ICollection<ConnectorDetail> connectorDetails, CancellationToken cancellationToken = default);
}
