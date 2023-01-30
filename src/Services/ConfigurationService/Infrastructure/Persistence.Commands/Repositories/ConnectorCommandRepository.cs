using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.Repositories;
public class ConnectorCommandRepository : CommandRepositoryBase<Connector>, IConnectorCommandRepository
{
    public ConnectorCommandRepository(AppDBContext dbContext) : base(dbContext)
    {

    }

    public async Task<bool> UpdateWithRelationAsync(Connector connector, CancellationToken cancellationToken = default)
    {
        _dbContext.Entry(connector).Property(x => x.Id).IsModified = false;
        _dbContext.Entry(connector).Property(x => x.Name).IsModified = false;
        _dbContext.Entry(connector).Property(x => x.Provider).IsModified = true;
        _dbContext.Entry(connector).Property(x => x.Identifier).IsModified = true;
        _dbContext.Entry(connector).Property(x => x.Status).IsModified = true;
        _dbContext.Entry(connector).Property(x => x.LastModifiedBy).IsModified = true;
        _dbContext.Entry(connector).Property(x => x.LastModifiedOn).IsModified = true;
        foreach (var connectorDetail in connector.ConnectorDetail)
        {
            _dbContext.Entry(connectorDetail).Property(x => x.ConnectorId).IsModified = false;
            _dbContext.Entry(connectorDetail).Property(x => x.AttributeName).IsModified = false;
            _dbContext.Entry(connectorDetail).Property(x => x.AttributeValue).IsModified = true;
            _dbContext.Entry(connectorDetail).Property(x => x.FieldType).IsModified = true;
            _dbContext.Entry(connectorDetail).Property(x => x.Type).IsModified = true;
            _dbContext.Entry(connectorDetail).Property(x => x.LastModifiedBy).IsModified = true;
            _dbContext.Entry(connectorDetail).Property(x => x.LastModifiedOn).IsModified = true;

        }

        return await Task.FromResult(true);
    }

    public async Task<bool> DeleteByNameAsync(string connectorName, CancellationToken cancellationToken = default)
    {
        Connector connector = await _dbContext.Connector.FirstOrDefaultAsync(x => x.Name == connectorName, cancellationToken);
        if (connector == null)
        {
            return false;
        }
        _dbContext.Remove(connector);
 
        return true;
    }
}
