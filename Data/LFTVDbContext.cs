using LFTV.Models;
using Microsoft.EntityFrameworkCore;

namespace LFTV.Data
{
    public class LFTVDbContext : DbContext
    {
        public LFTVDbContext(DbContextOptions<LFTVDbContext> options)
            : base(options)
        {
        }

        // DbSet pour les entités Programme et Emission
        public DbSet<Emission> Emissions { get; set; }
        public DbSet<Contenu> Contenus { get; set; }
        
    }
}
