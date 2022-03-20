using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class KaficContext : DbContext
    {
        public DbSet<Kafic> Kafici {get; set;}

        public DbSet<Sto> Stolovi {get; set;}

        public DbSet<Porudzbina> Porudzbine {get; set;}

        public KaficContext(DbContextOptions options):base(options)
        {
            
        }

    }

}