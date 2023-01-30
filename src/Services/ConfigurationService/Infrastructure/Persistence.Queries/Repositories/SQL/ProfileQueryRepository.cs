using Application.Queries.Common.Models;

namespace Persistence.Queries.Repositories.SQL;

public class ProfileQueryRepository : IProfileQueryRepository
{
    #region Private Fields

    private readonly IDbConnection _connection;

    #endregion Private Fields

    #region Public Constructors

    public ProfileQueryRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<ProfilesQueryResponse> Get(long profileId, CancellationToken cancellationToken = default)
    {
        ProfilesQueryResponse profile = new();
        List<ProfileDetailValueQuery> profileDetailValues = new();
        try
        {
            _connection?.Open();
            string query = @"SELECT * FROM Profile WHERE Id = @Id
                      SELECT * FROM ProfileDetail WHERE ProfileId IN (SELECT Id FROM Profile WHERE Id = @Id)
                      SELECT * FROM ProfileDetailValue WHERE ProfileDetailId IN (SELECT ID FROM ProfileDetail WHERE ProfileId = @Id) ";

            using (SqlMapper.GridReader multi = await _connection.QueryMultipleAsync(query, new { Id = profileId }))
            {
                profile = multi.ReadFirstOrDefault<ProfilesQueryResponse>();
                profile.ProfileDetail = multi.Read<ProfileDetailQuery>().ToList();
                profileDetailValues = multi.Read<ProfileDetailValueQuery>().ToList();
            }

            foreach (ProfileDetailQuery profileDetail in profile.ProfileDetail)
            {
                profileDetail.ProfileDetailValue = profileDetailValues.Where(t => t.ProfileDetailId == profileDetail.Id).ToList();
            }

            return profile;
        }
        finally
        {
            _connection?.Close();
        }
    }

    public async Task<IList<ProfilesQueryResponse>> GetAllAsync(int type = 0, CancellationToken cancellationToken = default)
    {
        string query = String.Empty;
        IEnumerable<ProfilesQueryResponse> profiles;
        IEnumerable<ProfileDetailQuery> profileDetails;
        IEnumerable<ProfileDetailValueQuery> profileDetailValues;

        if (type != 0)
        {
            query = @"SELECT * FROM Profile WHERE Type = @Type
                      SELECT * FROM ProfileDetail WHERE ProfileId IN (SELECT Id FROM Profile WHERE Type = @Type)
                      SELECT * FROM ProfileDetailValue ";
        }
        else
        {
            query = @"SELECT * FROM Profile
                      SELECT * FROM ProfileDetail
                      SELECT * FROM ProfileDetailValue ";
        }

        try
        {
            _connection?.Open();
            using (SqlMapper.GridReader multi = await _connection.QueryMultipleAsync(query, new { Type = type }))
            {
                profiles = multi.Read<ProfilesQueryResponse>();
                profileDetails = multi.Read<ProfileDetailQuery>();
                profileDetailValues = multi.Read<ProfileDetailValueQuery>();
            }

            foreach (ProfilesQueryResponse profile in profiles)
            {
                profile.ProfileDetail = profileDetails.Where(t => t.ProfileId == profile.Id).ToList();
                foreach (ProfileDetailQuery profileDetail in profile.ProfileDetail)
                {
                    profileDetail.ProfileDetailValue = profileDetailValues.Where(t => t.ProfileDetailId == profileDetail.Id).ToList();
                }
            }
            profiles = profiles.Where(p => !p.ProfileDetail.Any(d => d.AttributeName == "AUTHENTICATION_MECHANISM" && d.AttributeValue == "AUTHENTICATION_MOBILE")).OrderBy(o => o.Id);
            return profiles.ToList() ?? new List<ProfilesQueryResponse>();
        }
        finally
        {
            _connection?.Close();
        }
    }

    #endregion Public Methods
}