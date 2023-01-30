using Profile = Domain.Entities.Profile;

namespace Application.Commands.Contracts.Repositories.Commands
{
    public interface IProfileRepository
    {
        public Task<Profile> GetByIdAsync(int id);
    }
}