using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityCenterTracker.DTOs
{
    public class ReturnCrop_CropDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "jsonb")]
        public string Seasons { get; set; }

        public string? Note { get; set; }

        public int DaysToGrow { get; set; }

    }
}
