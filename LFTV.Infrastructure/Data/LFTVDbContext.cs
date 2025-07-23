using Microsoft.EntityFrameworkCore;
using LFTV.Domain.Entities;

namespace LFTV.Infrastructure.Data
{
    public class LFTVDbContext : DbContext
    {
        public LFTVDbContext(DbContextOptions<LFTVDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Emission> Emissions { get; set; }
        public DbSet<ProgramContent> ProgramContents { get; set; }
        public DbSet<CalendarEntry> CalendarEntries { get; set; }
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);        

            // Emission Configuration
            modelBuilder.Entity<Emission>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.StartTime).IsRequired();
                entity.Property(e => e.EndTime).IsRequired();
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
            });

            // ProgramContent Configuration
            modelBuilder.Entity<ProgramContent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.EpisodeUrl).HasMaxLength(500);

                // Foreign Key relationship
                entity.HasOne(e => e.Emission)
                      .WithMany(e => e.Contents)
                      .HasForeignKey(e => e.EmissionId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // CalendarEntry Configuration
            modelBuilder.Entity<CalendarEntry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Date).IsRequired();

                // Foreign Key relationship
                entity.HasOne(e => e.Emission)
                      .WithMany(e => e.CalendarEntries)
                      .HasForeignKey(e => e.EmissionId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Index for performance
                entity.HasIndex(e => e.Date);
            });

            // History Configuration
            modelBuilder.Entity<History>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.WatchedDate).IsRequired();

                // Foreign Key relationships
                entity.HasOne(e => e.Program)
                      .WithMany(e => e.HistoryEntries)
                      .HasForeignKey(e => e.ProgramContentId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Index for performance
                entity.HasIndex(e => e.WatchedDate);
                entity.HasIndex(e => new {e.ProgramContentId });
            });

            // Seed Data avec des valeurs STATIQUES
            SeedStaticData(modelBuilder);
        }

        private void SeedStaticData(ModelBuilder modelBuilder)
        {
            // Dates statiques fixes
            var baseDate = new DateTime(2025, 6, 29, 0, 0, 0, DateTimeKind.Utc);
            var createdDate = new DateTime(2025, 6, 28, 12, 0, 0, DateTimeKind.Utc);

            // Seed Users


            // Seed Emissions pour les 7 prochains jours
            modelBuilder.Entity<Emission>().HasData(
                // Jour 1 - Aujourd'hui (29/06/2025)
                new Emission { Id = 1, Name = "Journal du Matin - 29/06", Date = baseDate, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate },
                new Emission { Id = 2, Name = "Journal de 13h - 29/06", Date = baseDate, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(13, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate },
                new Emission { Id = 3, Name = "Film du Dimanche - 29/06", Date = baseDate, StartTime = new TimeSpan(20, 30, 0), EndTime = new TimeSpan(22, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=Film", CreatedAt = createdDate },

                // Jour 2 - 30/06/2025
                new Emission { Id = 4, Name = "Journal du Matin - 30/06", Date = baseDate.AddDays(1), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate },
                new Emission { Id = 5, Name = "Journal de 13h - 30/06", Date = baseDate.AddDays(1), StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(13, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate },
                new Emission { Id = 6, Name = "Série du Lundi - 30/06", Date = baseDate.AddDays(1), StartTime = new TimeSpan(20, 30, 0), EndTime = new TimeSpan(21, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=Serie", CreatedAt = createdDate },

                // Jour 3 - 01/07/2025
                new Emission { Id = 7, Name = "Journal du Matin - 01/07", Date = baseDate.AddDays(2), StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate },
                new Emission { Id = 8, Name = "Journal de 13h - 01/07", Date = baseDate.AddDays(2), StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(13, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate },
                new Emission { Id = 9, Name = "Film du Mardi - 01/07", Date = baseDate.AddDays(2), StartTime = new TimeSpan(20, 30, 0), EndTime = new TimeSpan(22, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=Film", CreatedAt = createdDate }
            );

            // Seed ProgramContents
            modelBuilder.Entity<ProgramContent>().HasData(
                // Programmes pour les émissions
                new ProgramContent { Id = 1, Name = "Actualités Nationales", Type = "News", Category = "Information", EmissionId = 1, IsWatched = false, CreatedAt = createdDate },
                new ProgramContent { Id = 2, Name = "Actualités Internationales", Type = "News", Category = "Information", EmissionId = 2, IsWatched = false, CreatedAt = createdDate },
                new ProgramContent { Id = 3, Name = "Le Parrain", Type = "Film", Category = "Drame", EmissionId = 3, IsWatched = false, ImageUrl = "https://via.placeholder.com/300x200?text=Le+Parrain", CreatedAt = createdDate },
                new ProgramContent { Id = 4, Name = "Actualités du Matin", Type = "News", Category = "Information", EmissionId = 4, IsWatched = false, CreatedAt = createdDate },
                new ProgramContent { Id = 5, Name = "Journal de Midi", Type = "News", Category = "Information", EmissionId = 5, IsWatched = false, CreatedAt = createdDate },
                new ProgramContent { Id = 6, Name = "Breaking Bad", Type = "Série", Category = "Drame", EmissionId = 6, IsWatched = false, ImageUrl = "https://via.placeholder.com/300x200?text=Breaking+Bad", CreatedAt = createdDate },
                new ProgramContent { Id = 7, Name = "Actualités du Matin", Type = "News", Category = "Information", EmissionId = 7, IsWatched = false, CreatedAt = createdDate },
                new ProgramContent { Id = 8, Name = "Journal de Midi", Type = "News", Category = "Information", EmissionId = 8, IsWatched = false, CreatedAt = createdDate },
                new ProgramContent { Id = 9, Name = "Casablanca", Type = "Film", Category = "Romance", EmissionId = 9, IsWatched = false, ImageUrl = "https://via.placeholder.com/300x200?text=Casablanca", CreatedAt = createdDate }
            );

            // Seed CalendarEntries
            modelBuilder.Entity<CalendarEntry>().HasData(
                new CalendarEntry { Id = 1, Date = baseDate, EmissionId = 1, CreatedAt = createdDate },
                new CalendarEntry { Id = 2, Date = baseDate, EmissionId = 2, CreatedAt = createdDate },
                new CalendarEntry { Id = 3, Date = baseDate, EmissionId = 3, CreatedAt = createdDate },
                new CalendarEntry { Id = 4, Date = baseDate.AddDays(1), EmissionId = 4, CreatedAt = createdDate },
                new CalendarEntry { Id = 5, Date = baseDate.AddDays(1), EmissionId = 5, CreatedAt = createdDate },
                new CalendarEntry { Id = 6, Date = baseDate.AddDays(1), EmissionId = 6, CreatedAt = createdDate },
                new CalendarEntry { Id = 7, Date = baseDate.AddDays(2), EmissionId = 7, CreatedAt = createdDate },
                new CalendarEntry { Id = 8, Date = baseDate.AddDays(2), EmissionId = 8, CreatedAt = createdDate },
                new CalendarEntry { Id = 9, Date = baseDate.AddDays(2), EmissionId = 9, CreatedAt = createdDate }
            );

            // Seed History
            modelBuilder.Entity<History>().HasData(
                new History { Id = 1, WatchedDate = baseDate.AddDays(-1), ProgramContentId = 1, CreatedAt = createdDate },
                new History { Id = 2, WatchedDate = baseDate.AddDays(-2), ProgramContentId = 3, CreatedAt = createdDate }
            );
        }
    }
}