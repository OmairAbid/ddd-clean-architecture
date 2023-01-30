namespace Persistence.Commands.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        #region Protected Fields

        protected readonly AdministratorLogCommandDbContext _dbContext;

        #endregion Protected Fields

        #region Public Constructors

        public ProfileRepository(AdministratorLogCommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<Profile> GetByIdAsync(int id)
        {
            return await _dbContext.Profile.FindAsync(id);
        }

        #endregion Public Methods
    }
}