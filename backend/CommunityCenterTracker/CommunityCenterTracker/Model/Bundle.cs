namespace CommunityCenterTracker.Model
{
    public class Bundle
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SectionId { get; set; }
        
        public Section? Section { get; set; }

        public ICollection<Item> Items { get; } = new List<Item>();
    }
}
