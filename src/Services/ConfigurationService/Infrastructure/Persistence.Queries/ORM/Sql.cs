using Microsoft.Data.SqlClient;

using System.Data;

namespace Persistence.Queries.ORM
{
	public class Sql : IDbConnection
	{
		#region Private Fields

		private readonly SqlConnection connection;

		private IDbTransaction Transaction { get; set; }

		#endregion Private Fields

		#region Public Properties

		public string ConnectionString { get; set; }

		public int ConnectionTimeout
		{
			get
			{
				return connection.ConnectionTimeout;
			}
		}

		public string Database
		{
			get
			{
				return connection.Database;
			}
		}

		public ConnectionState State
		{
			get
			{
				return connection.State;
			}
		}

		#endregion Public Properties

		#region Public Constructors

		public Sql(string connectionString)
		{
			ConnectionString = connectionString;
			connection = new SqlConnection(ConnectionString);
		}

		#endregion Public Constructors

		#region Public Methods

		public IDbTransaction BeginTransaction()
		{
			Transaction = connection.BeginTransaction();
			return Transaction;
		}

		public IDbTransaction BeginTransaction(IsolationLevel il)
		{
			Transaction = connection.BeginTransaction(il);
			return Transaction;
		}

		public void ChangeDatabase(string databaseName)
		{
			connection.ChangeDatabase(databaseName);
		}

		public void Close()
		{
			if (connection != null)
				connection.Close();

			if (Transaction != null)
			{
				Transaction.Dispose();
				Transaction = null;
			}
		}

		public IDbCommand CreateCommand()
		{
			return connection.CreateCommand();
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Open()
		{
			if (connection.State == ConnectionState.Closed ||
				connection.State == ConnectionState.Broken)
				connection.Open();
		}

		public async Task OpenAsync()
		{
			await connection.OpenAsync();
		}

		#endregion Public Methods

		#region Protected Methods

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				connection.Close();
				connection.Dispose();
			}
		}

		#endregion Protected Methods
	}
}