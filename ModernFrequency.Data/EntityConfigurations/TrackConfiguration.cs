using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernFrequency.Data.Models.Models;

public class TrackConfiguration : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.HasKey(track => track.TrackId);

        builder.Property(track => track.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(track => track.DurationInSeconds);

        builder.HasOne(track => track.Album)
            .WithMany(album => album.Tracks)
            .HasForeignKey(track => track.AlbumId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}