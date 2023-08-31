using CommunityCenterTracker.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityCenterTracker.DTOs.Items
{
    public class ItemDTO
    {

        public string Name { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "jsonb")]
        public string Seasons { get; set; }

        public string? Note { get; set; }

    }
}
