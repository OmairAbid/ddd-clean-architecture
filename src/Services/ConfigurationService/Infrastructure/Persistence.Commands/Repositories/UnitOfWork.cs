using Application.Commands.Contracts.Common;

namespace Persistence.Commands.Repositories;

internal class UnitOfWork : IUnitOfWork
{
	#region Private Fields

	private readonly AppDBContext _context;

	#endregion Private Fields

	#region Public Constructors

	public UnitOfWork(AppDBContext context)
	{
		_context = context;
	}

	#endregion Public Constructors

	#region Public Methods

	public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
	{
		return await _context.SaveChangesAsync(cancellationToken) > 0;
	}

    public void Dispose()
    {
        _context.Dispose();
    }

    #endregion Public Methods
}