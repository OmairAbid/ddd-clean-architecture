namespace Application.Queries.Contracts.Repositories
{
    public interface IRoleQueryRepository
    {
        #region Public Methods

        Task<AdministratorRoleQueryResponse> Get(long roleId, CancellationToken cancellationToken = default);

        Task<IList<GetAllAdministratorRoleResponse>> GetAllAsync(CancellationToken cancellationToken = default);

        #endregion Public Methods
    }
}