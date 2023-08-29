using Microsoft.EntityFrameworkCore;

namespace CommunityCenterTracker.Model
{
    public class CommunityCenterContext : DbContext
    {

        public DbSet<Section> Sections { get; set; }

        public CommunityCenterContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
