using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Persistence.Queries.ORM;
public class ORACLE : IDbConnection
{
    #region Private Members

    private readonly OracleConnection _Connection = null;

    #endregion

    #region Public Properties

    public string ConnectionString { get; set; }

    public int ConnectionTimeout
    {
        get
        {
            return _Connection.ConnectionTimeout;
        }
    }

    public string Database
    {
        get
        {
            return _Connection.Database;
        }
    }

    public ConnectionState State
    {
        get
        {
            return _Connection.State;
        }
    }

    #endregion

    #region Public Constructor

    public ORACLE(string connectionString)
    {
        ConnectionString = connectionString;
        _Connection = new OracleConnection(ConnectionString);
    }

    #endregion

    #region Public Methods

    public IDbTransaction BeginTransaction()
    {
        return _Connection.BeginTransaction();
    }

    public IDbTransaction BeginTransaction(IsolationLevel il)
    {
        return _Connection.BeginTransaction(il);
    }

    public void ChangeDatabase(string databaseName)
    {
        _Connection.ChangeDatabase(databaseName);
    }

    public void Close()
    {
        _Connection.Close();
    }

    public IDbCommand CreateCommand()
    {
        return _Connection.CreateCommand();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Open()
    {
        _Connection.Open();
    }

    #endregion

    #region Protected Methods

    // The bulk of the clean-up code is implemented in Dispose(bool)
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _Connection.Close();
            _Connection.Dispose();
        }
    }

    #endregion
}
