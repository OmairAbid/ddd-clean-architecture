namespace Persistence.Commands.Repositories
{
    public class ServiceplanRepository : IServiceplanRepository
    {
        #region Protected Fields

        protected readonly AdministratorLogCommandDbContext _dbContext;

        #endregion Protected Fields

        #region Public Constructors

        public ServiceplanRepository(AdministratorLogCommandDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<Serviceplan> GetByIdAsync(int id)
        {
            return await _dbContext.Serviceplan.FindAsync(id);
        }

        #endregion Public Methods
    }
}