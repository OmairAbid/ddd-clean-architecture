using Application.Queries.Contracts.Common;
using Domain.QueryEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.Repositories.ORACLE;
public class OraServicePlanQueryRepository : IServicePlanQueryRepository
{
    private readonly IUnitOfWork _unitOfWork;
    public OraServicePlanQueryRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ServicePlan>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        Dictionary<int, ServicePlan> _servicePlanDictionary = new Dictionary<int, ServicePlan>();
        const string _oracleQuery = @"SELECT * FROM  SERVICEPLAN SP
                                         INNER JOIN SERVICEPLANDETAIL SPD
                                         ON SP.ID = SPD.SERVICEPLANID
                                         ORDER BY SP.ID";
        IEnumerable<ServicePlan> _servicePlanList = await _unitOfWork.Connection.QueryAsync<ServicePlan, ServicePlanDetail, ServicePlan>(_oracleQuery,
            (servicePlan, servicePlanDetail) =>
            {
                ServicePlan _servicePlanEntry;
                if (!_servicePlanDictionary.TryGetValue(servicePlan.Id, out _servicePlanEntry))
                {
                    _servicePlanEntry = servicePlan;
                    _servicePlanDictionary.Add(_servicePlanEntry.Id, _servicePlanEntry);
                }
                if (!_servicePlanEntry.ServicePlanDetail.Exists(x => x.Id == servicePlanDetail.Id))
                {
                    _servicePlanEntry.ServicePlanDetail.Add(servicePlanDetail);
                }

                return _servicePlanEntry;
            }, splitOn: "ID");
        _servicePlanList.Distinct().ToList();
        return _servicePlanList;
    }
}
