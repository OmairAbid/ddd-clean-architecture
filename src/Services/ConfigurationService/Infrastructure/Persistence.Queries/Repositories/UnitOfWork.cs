using Application.Queries.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Queries.Repositories;
public class UnitOfWork : IUnitOfWork
{
    #region Public Properties

    public IDbConnection Connection { get; set; }
    public IDbTransaction Transaction { get; set; }

    #endregion Public Properties

    #region Public Constructor

    public UnitOfWork(IDbConnection connection)
    {
        Connection = connection;
    }

    #endregion Public Constructor

    #region Public Methods

    public void Open()
    {
        if (Connection.State == ConnectionState.Closed || Connection.State == ConnectionState.Broken)
            Connection.Open();
    }

    public void Close()
    {
        if (Connection != null)
            Connection.Close();

        if (Transaction != null)
        {
            Transaction.Dispose();
            Transaction = null;
        }
    }

    #endregion Public Methods

    #region Transaction Operations

    public void BeginTransaction()
    {
        Transaction = Connection.BeginTransaction();
    }

    public void CommitTransaction()
    {
        Transaction.Commit();
    }

    public void RollbackTransaction()
    {
        if (Transaction != null)
            Transaction.Rollback();
    }

    #endregion Transaction Operations

    #region Disposing

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            Close();
    }

    #endregion Disposing
}
