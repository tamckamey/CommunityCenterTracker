using AutoMapper;
using CommunityCenterTracker.DTOs;
using CommunityCenterTracker.Model;

namespace CommunityCenterTracker
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Bundle, BundleDTO>();
            CreateMap<Section, SectionDTO>();
        }
    }
}
