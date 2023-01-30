using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Contracts.Repositories;
public interface IConnectorCommandRepository: IAsyncCommandRepository<Connector>
{
    Task<bool> UpdateWithRelationAsync(Connector connector, CancellationToken cancellationToken = default);
    Task<bool> DeleteByNameAsync(string connectorName, CancellationToken cancellationToken = default);
}
