using Application.Queries.Common.Models;
using Application.Queries.Features.Role;

namespace Persistence.Queries.Repositories.SQL;

public class AdministratorRoleQueryRepository : IRoleQueryRepository
{
    #region Private Fields

    private readonly IDbConnection _connection;

    #endregion Private Fields

    #region Public Constructors

    public AdministratorRoleQueryRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<IList<GetAllAdministratorRoleResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        string sql = @"SELECT AdministratorRole.Id,AdministratorRole.Name,AdministratorRole.Description FROM AdministratorRole";

        try
        {
            _connection?.Open();
            return (await _connection.QueryAsync<GetAllAdministratorRoleResponse>(sql)).ToList();
        }
        finally
        {
            _connection?.Close();
        }
    }

    public async Task<AdministratorRoleQueryResponse> Get(long roleId, CancellationToken cancellationToken)
    {
        AdministratorRoleQueryResponse administratorRole;
        string query = @"SELECT * FROM AdministratorRole WHERE Id = @RoleId
                          SELECT AdministratorRoleDetail.* FROM AdministratorRoleDetail
                          INNER JOIN AdministratorRole ON AdministratorRole.Id = AdministratorRoleDetail.AdministratorRoleId
                          WHERE AdministratorRole.Id = @RoleId";
        try
        {
            _connection?.Open();
            using (SqlMapper.GridReader multi = await _connection.QueryMultipleAsync(query, new { RoleId = roleId }))
            {
                administratorRole = multi.ReadFirstOrDefault<AdministratorRoleQueryResponse>();
                administratorRole.AdministratorRoleDetail = multi.Read<AdministratorRoleDetail>().ToList();
            }
            return administratorRole;
        }
        finally
        {
            _connection?.Close();
        }
    }

    #endregion Public Methods
}