using Application.Queries.Contracts.Common;
using Domain.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.Repositories.SQL;
public class CurrencyQueryRepository : ICurrencyQueryRepository
{
    private readonly IUnitOfWork _unitOfWork;
    public CurrencyQueryRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Currency>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        const string sqlQuery = "SELECT * FROM Currency WHERE NAME IS NOT NULL";
        return await _unitOfWork.Connection.QueryAsync<Currency>(sqlQuery);
    }
}
