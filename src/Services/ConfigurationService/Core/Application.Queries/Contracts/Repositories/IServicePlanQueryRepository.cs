using Domain.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Contracts.Repositories;
public interface IServicePlanQueryRepository
{
    Task<IEnumerable<ServicePlan>> GetAllAsync(CancellationToken cancellationToken = default);
}
