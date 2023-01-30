using Application.Commands.Common.Enumerations;
using Application.Commands.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Commands.Repositories;
public class ProfileCommandRepository : CommandRepositoryBase<Profile>, IProfileCommandRepository
{
    public ProfileCommandRepository(AppDBContext dbContext) : base(dbContext)
    {
    }

    public async Task UpdateWithRelationAsync(long id, Profile profile, CancellationToken cancellationToken = default)
    {
        Profile _oldProfile = await _dbContext.Profile
                                            .Include(entity => entity.ProfileDetail)
                                            .ThenInclude(entity => entity.ProfileDetailValue)
                                            .FirstOrDefaultAsync(x => x.Id == id);

        _oldProfile.Name = profile.Name;
        _oldProfile.HMAC = profile.HMAC;
        _oldProfile.LastModifiedBy = profile.LastModifiedBy;

        int outerIndex = 0;
        foreach (ProfileDetail profileDetail in _oldProfile.ProfileDetail)
        {
            profileDetail.LastModifiedBy = profile.LastModifiedBy;
            profileDetail.HMAC = profile.ProfileDetail.ElementAt(outerIndex).HMAC;

            if (profileDetail.AttributeName == ActiveDirectoryAttribute.DOMAIN_ATTRIBUTES.ToString())
            {
                int innerIndex = 0;
                foreach (ProfileDetailValue detailValues in profileDetail.ProfileDetailValue)
                {
                    detailValues.LastModifiedBy = profile.LastModifiedBy;
                    detailValues.HMAC = profile.ProfileDetail.ElementAt(outerIndex).ProfileDetailValue.ElementAt(innerIndex).HMAC;
                    innerIndex++;
                }
            }
            outerIndex++;
        }
    }
}
