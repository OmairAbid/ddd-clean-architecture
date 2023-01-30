using Application.Queries.Common.Models;
using Application.Queries.Contracts.Common;
using Domain.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.Repositories.SQL;
public class ServicePlanQueryRepository: IServicePlanQueryRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public ServicePlanQueryRepository(IUnitOfWork unitOfWork)
    {
       _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ServicePlan>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        List<ServicePlan> _allServicePlans;
        List<ServicePlanDetail> _allServicePlanDetails;
        string _query = @"select * from ServicePlan
                            select * from ServicePlanDetail";

            using (SqlMapper.GridReader _multi = await _unitOfWork.Connection.QueryMultipleAsync(_query))
            {
                _allServicePlans = _multi.Read<ServicePlan>().ToList();
                _allServicePlanDetails = _multi.Read<ServicePlanDetail>().ToList();
            }
            foreach (ServicePlan _serviceplan in _allServicePlans)
            {
                _serviceplan.ServicePlanDetail = _allServicePlanDetails.Where(t => t.ServicePlanId == _serviceplan.Id).ToList();
            }
            return _allServicePlans;
        
    }
}
