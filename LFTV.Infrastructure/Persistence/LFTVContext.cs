using Microsoft.EntityFrameworkCore;
using LFTV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LFTV.Infrastructure.Persistence
{
    public class LFTVContext : DbContext
    {
        public LFTVContext(DbContextOptions<LFTVContext> options) : base(options) { }

        public DbSet<ProgramTv> TvPrograms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {             
                optionsBuilder.UseSqlServer("Server=localhost;Database=LFTVDb;Trusted_Connection=True;");
            }
        }
    }
}
