﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommunityCenterTracker.Model
{
    public class Fish
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "jsonb")]
        public string Seasons { get; set; }

        public string? Note { get; set; }

        [Column(TypeName = "jsonb")]
        public string Times { get; set; }

        [Column(TypeName = "jsonb")]
        public string Locations { get; set; }

    }
}
