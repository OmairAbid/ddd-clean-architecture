using Application.Queries.Contracts.Repositories.Queries;
using Application.Queries.Features;
using Dapper;
using Domain.Entities;
using Persistence.Queries.ORM;

namespace Persistence.Queries.Repositories;

public class AdministratorLogQueryRepository : IAdministratorLogQueryRepository
{
    #region Private Fields

    private readonly DapperContext _context;

    #endregion Private Fields

    #region Public Constructors

    public AdministratorLogQueryRepository(DapperContext Context)
    {
        _context = Context;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<IList<AdministratorQueryResponse>> GetAllAsync()
    {
        var query = @"SELECT * FROM AdministratorLog";
        using (var connection = _context.CreateConnection())
        {
            var response = await connection.QueryAsync<AdministratorQueryResponse>(query);
            return response.ToList();
        }
    }

    public async Task<AdministratorQueryResponse> GetAsync(string parms)
    {
        var query = @"select * from AdministratorLog where InfoKey = @AttributeName";
        using (var connection = _context.CreateConnection())
        {
            return await connection.QuerySingleAsync<AdministratorQueryResponse>(query, new { AttributeName = parms });
        }
    }

    public async Task<Tuple<IList<AdministratorQueryResponse>, int>> GetAsync(GetAdministratorLogsRequest adminSearchCriteria)
    {
        int total = 0;
        string condition = string.Empty;
        DateTime? ToDate = null;
        DateTime? FromDate = null;
        adminSearchCriteria.sortBy = "AdministratorLog." + adminSearchCriteria.sortBy;
        List<AdministratorQueryResponse> administratorLogs = new List<AdministratorQueryResponse>();
        string sortColumn = "CreatedOn";

        if (adminSearchCriteria.sortBy.Equals("AdministratorLog.CreatedOn"))
        {
            sortColumn = @"CASE @SortBy
										 WHEN 'AdministratorLog.CreatedOn' THEN AdministratorLog.CreatedOn
									     ELSE AdministratorLog.CreatedOn
                                         END";
        }
        else
        {
            sortColumn = @"CASE @SortBy
										 WHEN 'AdministratorLog.AdministratorEmail' THEN AdministratorLog.AdministratorEmail
									     ELSE AdministratorLog.AdministratorEmail
                                         END";
        }

        if (!string.IsNullOrEmpty(adminSearchCriteria.email))
        {
            condition += "WHERE AdministratorEmail like @AdministratorEmail";
        }

        if (!string.IsNullOrEmpty(adminSearchCriteria.name))
        {
            condition += !string.IsNullOrEmpty(condition) ? " AND Administrator.Name like @AdministratorName" : "WHERE Administrator.Name like @AdministratorName";
        }

        if (!string.IsNullOrEmpty(adminSearchCriteria.module))
        {
            condition += !string.IsNullOrEmpty(condition) ? " AND Module = @Module" : "WHERE Module = @Module";
        }

        if (!string.IsNullOrEmpty(adminSearchCriteria.activity))
        {
            condition += !string.IsNullOrEmpty(condition) ? " AND Action = @activity" : "WHERE Action = @activity";
        }

        if (!string.IsNullOrEmpty(adminSearchCriteria.dateFrom))
        {
            FromDate = DateTime.Parse(adminSearchCriteria.dateFrom);
            condition += !string.IsNullOrEmpty(condition) ? " AND AdministratorLog.CreatedOn >= @FromDate" : "WHERE AdministratorLog.CreatedOn >= @FromDate";
        }

        if (!string.IsNullOrEmpty(adminSearchCriteria.dateTo))
        {
            ToDate = DateTime.Parse(adminSearchCriteria.dateTo).AddDays(1);
            condition += !string.IsNullOrEmpty(condition) ? " AND AdministratorLog.CreatedOn <= @ToDate" : "WHERE AdministratorLog.CreatedOn <= @ToDate";
        }

        string sqlQuery = @"SELECT *
                                    FROM (SELECT ROW_NUMBER() OVER (ORDER BY " + sortColumn
                                + @" " + (adminSearchCriteria.isAsc ? "ASC" : "DESC") + @") AS RowNum ,AdministratorLog.*,Administrator.Name,AdministratorLogDetail.Detail as EvidenceLog FROM AdministratorLog
                                    inner join Administrator on AdministratorLog.AdministratorEmail=Administrator.EmailAddress
                                    left join AdministratorLogDetail on AdministratorLog.Id = AdministratorLogDetail.AdministratorLogId
                                    " + condition + @" ) as Result WHERE RowNum > @From
                                          AND RowNum <= @To

                                            SELECT COUNT(*) AS Total FROM AdministratorLog left join Administrator on AdministratorLog.AdministratorEmail=Administrator.EmailAddress  " + condition + "";

        using (var connection = _context.CreateConnection())
        {
            using (SqlMapper.GridReader multi = await connection.QueryMultipleAsync(sqlQuery, new
            {
                From = adminSearchCriteria.start,
                To = adminSearchCriteria.end,
                AdministratorEmail = ('%' + adminSearchCriteria.email + '%'),
                AdministratorName = ('%' + adminSearchCriteria.name + '%'),
                //Module = adminSearchCriteria.module,
                adminSearchCriteria.activity,
                FromDate,
                ToDate,
                SortBy = adminSearchCriteria.sortBy
            }))
            {
                administratorLogs = multi.Read<AdministratorQueryResponse>().ToList();
                total = multi.Read<int>().FirstOrDefault();
            };
        }
        return new Tuple<IList<AdministratorQueryResponse>, int>(administratorLogs, total);
    }

    #endregion Public Methods
}