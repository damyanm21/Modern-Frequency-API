using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernFrequency.Data.Models.Models;
using System.ComponentModel.DataAnnotations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(artist => artist.ArtistId);
        builder.Property(artist => artist.ArtistId)
           .ValueGeneratedOnAdd();

        builder.Property(artist => artist.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(artist => artist.Genre)
            .IsRequired()
            .HasMaxLength(11)
            .HasConversion<int>();
    }
}