

using Application.Queries.Features.Connectors.Get;
using Application.Queries.Features.SystemSettings;
using Profile = AutoMapper.Profile;

namespace Application.Common.Mappings;
public class MappingProfile : Profile
{
	public MappingProfile()
	{
        CreateMap<SystemSetting, GetSystemSettingQueryResponse>().ReverseMap()
        .MaxDepth(1);

        CreateMap<SystemSettingsDetails, SystemSettingsDetailsResponse>()
            .PreserveReferences();

        CreateMap<Connector, GetConnectorQueryResponse>().ReverseMap()
            .MaxDepth(1);

        CreateMap<ConnectorDetail, ConnectorDetailsResponse>()
           .PreserveReferences();

        CreateMap<ConnectionProvider, ConnectionProviderQueryResponse>().ReverseMap();
        CreateMap<ConnectionProviderParameter, ConnectionProviderParametersQueryResponse>().ReverseMap();

        CreateMap<ConnectionProviderDetail, ConnectionProviderDetailResponse>()
            .PreserveReferences();
        CreateMap<ConnectionProviderParameter, ConnectionProviderParameterResponse>()
            .PreserveReferences();
    }
}
