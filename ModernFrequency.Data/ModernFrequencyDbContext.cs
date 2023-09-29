using Microsoft.EntityFrameworkCore;
using ModernFrequency.Data.EntityConfigurations;
using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Data
{
    public class ModernFrequencyDbContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<AlbumArtist> AlbumArtists { get; set; }


        public ModernFrequencyDbContext(DbContextOptions<ModernFrequencyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumConfiguration());
            modelBuilder.ApplyConfiguration(new TrackConfiguration());
            modelBuilder.ApplyConfiguration(new AlbumArtistConfiguration());
        }
    }
}
