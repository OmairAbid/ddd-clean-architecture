using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Persistence.Queries.ORM;

public class DapperContext
{
    #region Private Fields

    private readonly IConfiguration _configuration;

    #endregion Private Fields

    #region Public Constructors

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    #endregion Public Constructors

    #region Public Methods

    public IDbConnection CreateConnection()
        => new SqlConnection(_configuration.GetSection("ConnectionStrings:Database").Value);

    #endregion Public Methods
}