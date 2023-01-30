namespace Application.Queries.Contracts.Repositories
{
    public interface IProfileQueryRepository
    {
        #region Public Methods

        Task<ProfilesQueryResponse> Get(long Id, CancellationToken cancellationToken = default);

        Task<IList<ProfilesQueryResponse>> GetAllAsync(int type = 0, CancellationToken cancellationToken = default);

        #endregion Public Methods
    }
}