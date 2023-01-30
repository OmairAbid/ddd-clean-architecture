using Profile = Domain.Entities.Profile;

namespace Application.Commands.Contracts.Repositories;
public interface IProfileCommandRepository:IAsyncCommandRepository<Profile>
{
    Task UpdateWithRelationAsync(long id, Profile profile, CancellationToken cancellationToken);
}
