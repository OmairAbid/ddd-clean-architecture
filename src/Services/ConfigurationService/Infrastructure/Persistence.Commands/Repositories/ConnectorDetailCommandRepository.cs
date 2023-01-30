using MassTransit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.Repositories;
public class ConnectorDetailCommandRepository: CommandRepositoryBase<ConnectorDetail>, IConnectorDetailCommandRepository
{
	public ConnectorDetailCommandRepository(AppDBContext dbContext) :base(dbContext)
	{

    }

	public async Task<bool> BulkInsertAsync(ICollection<ConnectorDetail> connectorDetails, CancellationToken cancellationToken = default)
	{
		await _dbContext.AddRangeAsync(connectorDetails,cancellationToken);
		return true;
	}

    public async Task<bool> BulkUpdateAsync(ICollection<ConnectorDetail> connectorDetails, CancellationToken cancellationToken = default)
    {
        _dbContext.UpdateRange(connectorDetails, cancellationToken);
		return await Task.FromResult(true);
    }
}
