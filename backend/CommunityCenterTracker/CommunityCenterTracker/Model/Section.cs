using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityCenterTracker.Model
{
    public class Section
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public List<Bundle>? Bundles { get; set; }

    }
}
