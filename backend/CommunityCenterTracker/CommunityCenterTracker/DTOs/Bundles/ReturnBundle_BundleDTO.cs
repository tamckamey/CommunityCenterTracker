using CommunityCenterTracker.DTO;
using CommunityCenterTracker.DTOs;
using CommunityCenterTracker.Model;

namespace CommunityCenterTracker.DTOs
{
    public class ReturnBundle_BundleDTO

    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ReturnSection_SectionDTO? Section { get; set; }

        public ICollection<ReturnCrop_CropDTO> Crops { get; } = new List<ReturnCrop_CropDTO>();

        public ICollection<ReturnFish_FishDTO> Fishes { get; } = new List<ReturnFish_FishDTO>();
    }
}
