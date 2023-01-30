namespace Persistence.Commands.Repositories;

public class AdministratorLogRepository : CommandRepositoryBase<AdministratorLog>, IAdministratorLogRepository
{
    #region Public Constructors

    public AdministratorLogRepository(AdministratorLogCommandDbContext dbContext) : base(dbContext)
    {
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<bool> AddAdministratorLogAsync(AdministratorLog administratorLog)
    {
        int _result = 0;
        _dbContext.Add(administratorLog);
        _dbContext.Entry<AdministratorLog>(administratorLog).State = EntityState.Added;
        _result = await _dbContext.SaveChangesAsync();
        return Convert.ToBoolean(_result);
    }

    public async Task<AdministratorLog?> GetByAction(string action)
    {
        return await _dbContext.AdministratorLog.FirstOrDefaultAsync(x => x.Action == action);
    }

    #endregion Public Methods
}