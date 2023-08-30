using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CommunityCenterTracker.Model
{
    public class Section
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [JsonIgnore]
        public ICollection<Bundle> Bundles { get; set; } = new List<Bundle>();

    }
}
