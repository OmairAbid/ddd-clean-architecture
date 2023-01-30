namespace Application.Commands.Contracts.Common;

public interface IUnitOfWork
{
	Task<bool> CommitAsync(CancellationToken cancellationToken = default);
}