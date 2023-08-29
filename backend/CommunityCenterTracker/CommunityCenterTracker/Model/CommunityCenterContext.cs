using Microsoft.EntityFrameworkCore;
using CommunityCenterTracker.Model.Items;

namespace CommunityCenterTracker.Model
{
    public class CommunityCenterContext : DbContext
    {

        public DbSet<Section> Sections { get; set; }
        public DbSet<Bundle> Bundles { get; set; }
        public DbSet<Item> Items { get; set; }
        

        public CommunityCenterContext(DbContextOptions options) : base(options)
        {
            
        }
        

        public DbSet<CommunityCenterTracker.Model.Items.Crop>? Crop { get; set; }
        

        public DbSet<CommunityCenterTracker.Model.Items.Fish>? Fish { get; set; }


    }
}
