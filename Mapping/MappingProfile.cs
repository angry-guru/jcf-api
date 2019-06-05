using System;
using AutoMapper;
using jcf_api.Types;

namespace jcf_api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CarbonFootprintResponse, CarbonFootprintResult>()
                .ForMember(x => x.Cost, y => y.MapFrom(z => Math.Round(z.Total_Cost, 2)))
                .ForMember(x => x.Tons, y => y.MapFrom(z => Math.Round(z.Tons, 2)));
        }
    }
}
