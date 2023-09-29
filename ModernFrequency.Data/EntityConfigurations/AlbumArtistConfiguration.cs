using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Data.EntityConfigurations
{
    public class AlbumArtistConfiguration : IEntityTypeConfiguration<AlbumArtist>
    {
        public void Configure(EntityTypeBuilder<AlbumArtist> builder)
        {
            builder.HasKey(aa => new { aa.AlbumId, aa.ArtistId });
            builder
            .HasOne(aa => aa.Album)
            .WithMany(album => album.AlbumArtists)
            .HasForeignKey(aa => aa.AlbumId)
            .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(aa => aa.Artist)
                .WithMany(album => album.Albums)
                .HasForeignKey(aa => aa.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(aa => aa.Artist)
                .WithMany(artist => artist.Albums)
                .HasForeignKey(aa => aa.ArtistId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
