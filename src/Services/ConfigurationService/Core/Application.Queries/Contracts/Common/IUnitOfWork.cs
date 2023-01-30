using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Contracts.Common;
public interface IUnitOfWork:IDisposable
{
    #region Public Properties

    IDbConnection Connection { get; set; }
    IDbTransaction Transaction { get; set; }

    #endregion Public Properties

    #region Public Methods

    /// <summary>
    /// Creating Transaction
    /// </summary>
    void BeginTransaction();

    /// <summary>
    /// Close Connection, i.e connection state changed to closed
    /// </summary>
    void Close();

    /// <summary>
    /// Saving changes
    /// </summary>
    void CommitTransaction();

    /// <summary>
    /// Open connection
    /// </summary>
    void Open();

    /// <summary>
    /// Incase of failure , Rollback transaction
    /// </summary>
    void RollbackTransaction();

    #endregion Public Methods
}
