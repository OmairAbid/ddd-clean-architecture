using Application.Queries.Features;
using Profile = AutoMapper.Profile;

namespace Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AdministratorQueryResponse, GetAdministratorLogResponse>().ReverseMap();
    }
}