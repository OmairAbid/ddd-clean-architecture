using Application.Queries.Common.Models;
using Application.Queries.Features.Role;

namespace Persistence.Queries.Repositories.ORACLE;

public class OraAdministratorRoleQueryRepository : IRoleQueryRepository
{
    #region Private Fields

    private readonly IDbConnection _connection;

    #endregion Private Fields

    #region Public Constructors

    public OraAdministratorRoleQueryRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public Task<AdministratorRoleQueryResponse> Get(long roleId, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
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

    #endregion Public Methods
}