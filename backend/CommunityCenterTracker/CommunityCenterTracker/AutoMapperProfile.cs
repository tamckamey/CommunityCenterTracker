using AutoMapper;
using CommunityCenterTracker.DTO;
using CommunityCenterTracker.DTOs;
using CommunityCenterTracker.Model;

namespace CommunityCenterTracker
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Bundle DTOs
            CreateMap<Bundle, ReturnBundle_BundleDTO>();
            CreateMap<CreateBundle_BundleDTO, Bundle>();

            // Crop DTOs
            CreateMap<Crop, ReturnCrop_CropDTO>();
            CreateMap<CreateCrop_CropDTO, Crop>();

            // Fish DTOs
            CreateMap<Fish, ReturnFish_FishDTO>();
            CreateMap<CreateFish_FishDTO, Fish>();

            // Section DTOs
            CreateMap<Section, ReturnSection_SectionDTO>();
            CreateMap<CreateSection_SectionDTO, Section>();
        }
    }
}
