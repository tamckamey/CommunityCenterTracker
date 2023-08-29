using Microsoft.Identity.Client;

namespace CommunityCenterTracker.Model
{
    public class Section
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public List<Bundle> Bundles { get; set; }

    }
}
