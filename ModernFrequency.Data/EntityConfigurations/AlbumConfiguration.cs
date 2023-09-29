using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernFrequency.Data.Models.Models;

public class AlbumConfiguration : IEntityTypeConfiguration<Album>
{
    public void Configure(EntityTypeBuilder<Album> builder)
    {
        builder.HasKey(album => album.AlbumId);

        builder.Property(album => album.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(album => album.ReleaseYear);

        builder
            .HasMany(album => album.AlbumArtists)
            .WithOne(albumArtist => albumArtist.Album)
            .HasForeignKey(albumArtist => albumArtist.AlbumId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}