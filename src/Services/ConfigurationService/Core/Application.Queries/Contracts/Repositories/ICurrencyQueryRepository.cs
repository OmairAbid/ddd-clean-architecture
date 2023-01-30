using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Contracts.Repositories;
public interface ICurrencyQueryRepository
{
    /// <summary>
    /// Get all currecy
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Currency>> GetAllAsync(CancellationToken cancellationToken = default);
}
