using Application.Queries.Contracts.Common;
using Domain.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.Repositories.ORACLE;
public class OraCurrencyQueryRepository : ICurrencyQueryRepository
{
    private readonly IUnitOfWork _unitOfWork;
    public OraCurrencyQueryRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public Task<IEnumerable<Currency>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return _unitOfWork.Connection.QueryAsync<Currency>("SELECT * FROM Currency WHERE NAME IS NOT NULL");
    }
}
