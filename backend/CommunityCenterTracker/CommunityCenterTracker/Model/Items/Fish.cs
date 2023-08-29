using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityCenterTracker.Model.Items
{
    public class Fish : Item
    {

        [Column(TypeName = "jsonb")]
        public string Times { get; set; }

        [Column(TypeName = "jsonb")]
        public string Locations { get; set; }

    }
}
