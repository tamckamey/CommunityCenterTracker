using AutoMapper;
using CommunityCenterTracker.DTOs.Bundles;
using CommunityCenterTracker.DTOs.Items;
using CommunityCenterTracker.DTOs.Sections;
using CommunityCenterTracker.Model;

namespace CommunityCenterTracker
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Bundles
            CreateMap<Bundle, ReturnBundle_BundleDTO>();
            CreateMap<Bundle, CreateBundle_BundleDTO>();

            // Sections
            CreateMap<Section, SectionDTO>();

            // Items
            CreateMap<Item, ItemDTO>();
        }
    }
}
