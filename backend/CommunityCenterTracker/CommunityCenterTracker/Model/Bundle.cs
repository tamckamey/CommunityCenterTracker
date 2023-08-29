namespace CommunityCenterTracker.Model
{
    public class Bundle
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public Section Section { get; set; }

        public List<Item> Items { get; set; }
    }
}
