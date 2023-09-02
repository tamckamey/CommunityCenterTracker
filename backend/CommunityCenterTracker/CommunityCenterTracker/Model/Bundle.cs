namespace CommunityCenterTracker.Model
{
    public class Bundle
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SectionId { get; set; }
        
        public Section? Section { get; set; }

        public ICollection<Fish>? Fishes { get; } = new List<Fish>();

        public ICollection<Crop>? Crops { get; } = new List<Crop>();
    }
}
