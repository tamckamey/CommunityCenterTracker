using CommunityCenterTracker.DTOs.Items;
using CommunityCenterTracker.DTOs.Sections;
using CommunityCenterTracker.Model;

namespace CommunityCenterTracker.DTOs.Bundles
{
    public class ReturnBundle_BundleDTO
    {
        public string Name { get; set; }

        public SectionDTO? Section { get; set; }

        public ICollection<ItemDTO> Items { get; } = new List<ItemDTO>();
    }
}
