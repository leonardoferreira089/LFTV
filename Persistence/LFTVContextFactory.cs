using LFTV.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LFTV.Infrastructure.Factories
{
    public class LFTVContextFactory : IDesignTimeDbContextFactory<LFTVContext>
    {
        public LFTVContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LFTVContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=LFTVDb;Trusted_Connection=True;");

            return new LFTVContext(optionsBuilder.Options);
        }
    }
}

