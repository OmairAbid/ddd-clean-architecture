using Application.Queries.Common.Models;
using Application.Queries.Features.Role;

namespace Persistence.Queries.Repositories.ORACLE;

public class OraProfileQueryRepository : IProfileQueryRepository
{
    #region Private Fields

    private readonly IDbConnection _connection;

    #endregion Private Fields

    #region Public Constructors

    public OraProfileQueryRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    #endregion Public Constructors

    #region Public Methods

    public async Task<ProfilesQueryResponse> Get(long Id, CancellationToken cancellationToken = default)
    {
        Dictionary<int, ProfilesQueryResponse> _profileDictionary = new Dictionary<int, ProfilesQueryResponse>();
        ProfilesQueryResponse profileList = new();

        const string SqlQuery = @"SELECT * FROM PROFILE P
                                      INNER JOIN PROFILEDETAIL PD ON P.ID = PD.PROFILEID
                                      LEFT JOIN PROFILEDETAILVALUE PDV ON PD.ID = PDV.PROFILEDETAILID
                                     WHERE P.ID = :ProfileId
									 ORDER BY P.ID  ";
        try
        {
            _connection?.Open();
            profileList = (await _connection.QueryAsync<ProfilesQueryResponse, ProfileDetailQuery, ProfileDetailValueQuery, ProfilesQueryResponse>(SqlQuery, (profile, profileDetail, profileDetailValue) =>
            {
                ProfilesQueryResponse _profileEntry;
                if (!_profileDictionary.TryGetValue(profile.Id, out _profileEntry))
                {
                    _profileEntry = profile;
                    _profileDictionary.Add(_profileEntry.Id, _profileEntry);
                }

                if (_profileEntry.ProfileDetail.FirstOrDefault(x => x.Id == profileDetail.Id) == null)
                {
                    if (profileDetailValue != null)
                    {
                        profileDetail.ProfileDetailValue.Add(profileDetailValue);
                        _profileEntry.ProfileDetail.Add(profileDetail);
                    }
                    else
                    {
                        _profileEntry.ProfileDetail.Add(profileDetail);
                    }
                }
                else
                {
                    if (profileDetailValue != null && !string.IsNullOrEmpty(profileDetailValue.AttributeName))
                    {
                        _profileEntry.ProfileDetail.FirstOrDefault(x => x.Id == profileDetail.Id).ProfileDetailValue.Add(profileDetailValue);
                    }
                }
                return _profileEntry;
            }, splitOn: "Id, ProfileDetailId", param: new { ProfileId = Id })).Distinct().FirstOrDefault();
        }
        finally
        {
            _connection?.Close();
        }
        return profileList;
    }

    public async Task<IList<ProfilesQueryResponse>> GetAllAsync(int type = 0, CancellationToken cancellationToken = default)
    {
        Dictionary<int, ProfilesQueryResponse> _profileDictionary = new Dictionary<int, ProfilesQueryResponse>();
        List<ProfilesQueryResponse> profileList = new();

        string SqlQuery = String.Empty;

        if (type == 0)
        {
            SqlQuery = @"SELECT * FROM PROFILE P
                                      INNER JOIN PROFILEDETAIL PD ON P.ID = PD.PROFILEID
                                      LEFT JOIN PROFILEDETAILVALUE PDV ON PD.ID = PDV.PROFILEDETAILID
                                      ORDER BY P.ID";
        }
        else
        {
            SqlQuery = @"SELECT * FROM PROFILE P
                                      INNER JOIN PROFILEDETAIL PD ON P.ID = PD.PROFILEID
                                      LEFT JOIN PROFILEDETAILVALUE PDV ON PD.ID = PDV.PROFILEDETAILID
                                      WHERE P.TYPE = :Type
                                      ORDER BY P.ID";
        }

        try
        {
            _connection?.Open();
            profileList = (await _connection.QueryAsync<ProfilesQueryResponse, ProfileDetailQuery, ProfileDetailValueQuery, ProfilesQueryResponse>(SqlQuery, (profile, profileDetail, profileDetailValue) =>
            {
                ProfilesQueryResponse _profileEntry;
                if (!_profileDictionary.TryGetValue(profile.Id, out _profileEntry))
                {
                    _profileEntry = profile;
                    _profileDictionary.Add(_profileEntry.Id, _profileEntry);
                }

                if (_profileEntry.ProfileDetail.FirstOrDefault(x => x.Id == profileDetail.Id) == null)
                {
                    if (profileDetailValue != null)
                    {
                        profileDetail.ProfileDetailValue.Add(profileDetailValue);
                        _profileEntry.ProfileDetail.Add(profileDetail);
                    }
                    else
                    {
                        _profileEntry.ProfileDetail.Add(profileDetail);
                    }
                }
                else
                {
                    if (profileDetailValue != null && !string.IsNullOrEmpty(profileDetailValue.AttributeName))
                    {
                        _profileEntry.ProfileDetail.FirstOrDefault(x => x.Id == profileDetail.Id).ProfileDetailValue.Add(profileDetailValue);
                    }
                }
                return _profileEntry;
            }, splitOn: "Id, ProfileDetailId", param: new { Type = type })).Distinct().ToList();
            profileList = profileList.Where(p => !p.ProfileDetail.Any(d => d.AttributeName == "AUTHENTICATION_MECHANISM" && d.AttributeValue == "AUTHENTICATION_MOBILE")).ToList();
        }
        finally
        {
            _connection?.Close();
        }
        return profileList;
    }

    #endregion Public Methods
}