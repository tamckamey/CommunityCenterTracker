using Microsoft.EntityFrameworkCore;

namespace CommunityCenterTracker.Model
{
    public class CommunityCenterContext : DbContext
    {

        public DbSet<Section> Sections { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<Fish> Fishes { get; set; }

        public DbSet<Crop> Crops { get; set; }


        public CommunityCenterContext(DbContextOptions options) : base(options)
        {
            
        }
        

        public DbSet<Crop>? Crop { get; set; }
        

        public DbSet<Fish>? Fish { get; set; }


    }
}
