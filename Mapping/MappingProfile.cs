using AutoMapper;
using jcf_api.Types;

namespace jcf_api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarbonFootprintResponse, CarbonFootprintResult>()
                .ForMember(x => x.Cost, y => y.MapFrom(z => z.Total_Cost));
        }
    }
}
