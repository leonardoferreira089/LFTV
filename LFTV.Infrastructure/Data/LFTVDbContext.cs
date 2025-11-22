using Microsoft.EntityFrameworkCore;
using LFTV.Domain.Entities;
using LFTV.Domain.Enums;

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
            modelBuilder.Entity<Emission>()
                .HasOne(e => e.ProgramContent)
                .WithMany(pc => pc.Emissions) // navigation inverse
                .HasForeignKey(e => e.ProgramContentId)
                .OnDelete(DeleteBehavior.SetNull);


            // ProgramContent Configuration
            modelBuilder.Entity<ProgramContent>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Type).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Category).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.EpisodeUrl).HasMaxLength(500);

            });

            // CalendarEntry Configuration
            modelBuilder.Entity<CalendarEntry>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Jour).IsRequired();

                // Foreign Key relationship
                entity.HasOne(e => e.Emission)
                      .WithMany(e => e.CalendarEntries)
                      .HasForeignKey(e => e.EmissionId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Index for performance
                entity.HasIndex(e => e.Jour);
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

            // Seed Emissions pour les 7 prochains jours (ProgramContentId = null par défaut, sauf si tu veux en associer un)
            modelBuilder.Entity<Emission>().HasData(
                new Emission { Id = 1, Name = "Journal du Matin", Jour = DayOfWeekEnum.Lundi, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate, ProgramContentId = 1 },
                new Emission { Id = 2, Name = "Journal de 13h", Jour = DayOfWeekEnum.Lundi, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(13, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate, ProgramContentId = 2 },
                new Emission { Id = 3, Name = "Film du Dimanche", Jour = DayOfWeekEnum.Dimanche, StartTime = new TimeSpan(20, 30, 0), EndTime = new TimeSpan(22, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=Film", CreatedAt = createdDate, ProgramContentId = 3 },
                new Emission { Id = 4, Name = "Journal du Matin - 30/06", Jour = DayOfWeekEnum.Mardi, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate, ProgramContentId = 4 },
                new Emission { Id = 5, Name = "Journal de 13h - 30/06", Jour = DayOfWeekEnum.Mardi, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(13, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate, ProgramContentId = 5 },
                new Emission { Id = 6, Name = "Série du Lundi - 30/06", Jour = DayOfWeekEnum.Mardi, StartTime = new TimeSpan(20, 30, 0), EndTime = new TimeSpan(21, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=Serie", CreatedAt = createdDate, ProgramContentId = 6 },
                new Emission { Id = 7, Name = "Journal du Matin - 01/07", Jour = DayOfWeekEnum.Mercredi, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(8, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate, ProgramContentId = 7 },
                new Emission { Id = 8, Name = "Journal de 13h - 01/07", Jour = DayOfWeekEnum.Mercredi, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(13, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=News", CreatedAt = createdDate, ProgramContentId = 8 },
                new Emission { Id = 9, Name = "Film du Mardi - 01/07", Jour = DayOfWeekEnum.Mercredi, StartTime = new TimeSpan(20, 30, 0), EndTime = new TimeSpan(22, 30, 0), ImageUrl = "https://via.placeholder.com/300x200?text=Film", CreatedAt = createdDate, ProgramContentId = 9 }
            );

            // Seed ProgramContents. Utilise EmissionSelectionId pour la suggestion UI, pas de vrai lien fort
            modelBuilder.Entity<ProgramContent>().HasData(
                new ProgramContent { Id = 1, Name = "Actualités Nationales", Type = "News", Category = "Information", ImageUrl = "https://via.placeholder.com/300x200?text=Actu+Nat", IsWatched = false, CreatedAt = createdDate, EmissionSelectionId = 1 },
                new ProgramContent { Id = 2, Name = "Actualités Internationales", Type = "News", Category = "Information", ImageUrl = "https://via.placeholder.com/300x200?text=Actu+Int", IsWatched = false, CreatedAt = createdDate, EmissionSelectionId = 2 },
                new ProgramContent { Id = 3, Name = "Le Parrain", Type = "Film", Category = "Drame", ImageUrl = "https://via.placeholder.com/300x200?text=Le+Parrain", IsWatched = false, CreatedAt = createdDate, EmissionSelectionId = 3 },
                new ProgramContent { Id = 4, Name = "Actualités du Matin", Type = "News", Category = "Information", ImageUrl = "https://via.placeholder.com/300x200?text=Actu+Matin", IsWatched = false, CreatedAt = createdDate, EmissionSelectionId = 4 },
                new ProgramContent { Id = 5, Name = "Journal de Midi", Type = "News", Category = "Information", ImageUrl = "https://via.placeholder.com/300x200?text=Journal+Midi", IsWatched = false, CreatedAt = createdDate, EmissionSelectionId = 5 },
                new ProgramContent { Id = 6, Name = "Breaking Bad", Type = "Série", Category = "Drame", ImageUrl = "https://via.placeholder.com/300x200?text=Breaking+Bad", IsWatched = false, CreatedAt = createdDate, EmissionSelectionId = 6 },
                new ProgramContent { Id = 7, Name = "Actualités du Matin", Type = "News", Category = "Information", ImageUrl = "https://via.placeholder.com/300x200?text=Actu+Matin", IsWatched = false, CreatedAt = createdDate, EmissionSelectionId = 7 },
                new ProgramContent { Id = 8, Name = "Journal de Midi", Type = "News", Category = "Information", ImageUrl = "https://via.placeholder.com/300x200?text=Journal+Midi", IsWatched = false, CreatedAt = createdDate, EmissionSelectionId = 8 },
                new ProgramContent { Id = 9, Name = "Casablanca", Type = "Film", Category = "Romance", ImageUrl = "https://via.placeholder.com/300x200?text=Casablanca", IsWatched = false, CreatedAt = createdDate, EmissionSelectionId = 9 }
            );

            // Seed CalendarEntries
            modelBuilder.Entity<CalendarEntry>().HasData(
                new CalendarEntry { Id = 1, Jour = DayOfWeekEnum.Lundi, EmissionId = 1, CreatedAt = createdDate },
                new CalendarEntry { Id = 2, Jour = DayOfWeekEnum.Lundi, EmissionId = 2, CreatedAt = createdDate },
                new CalendarEntry { Id = 3, Jour = DayOfWeekEnum.Lundi, EmissionId = 3, CreatedAt = createdDate },
                new CalendarEntry { Id = 4, Jour = DayOfWeekEnum.Mardi, EmissionId = 4, CreatedAt = createdDate },
                new CalendarEntry { Id = 5, Jour = DayOfWeekEnum.Mardi, EmissionId = 5, CreatedAt = createdDate },
                new CalendarEntry { Id = 6, Jour = DayOfWeekEnum.Mardi, EmissionId = 6, CreatedAt = createdDate },
                new CalendarEntry { Id = 7, Jour = DayOfWeekEnum.Mercredi, EmissionId = 7, CreatedAt = createdDate },
                new CalendarEntry { Id = 8, Jour = DayOfWeekEnum.Mercredi, EmissionId = 8, CreatedAt = createdDate },
                new CalendarEntry { Id = 9, Jour = DayOfWeekEnum.Mercredi, EmissionId = 9, CreatedAt = createdDate }
            );

            // Seed History
            modelBuilder.Entity<History>().HasData(
                new History { Id = 1, WatchedDate = baseDate.AddDays(-1), ProgramContentId = 1, CreatedAt = createdDate },
                new History { Id = 2, WatchedDate = baseDate.AddDays(-2), ProgramContentId = 3, CreatedAt = createdDate }
            );
        }
    }
}