﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernFrequency.Data.Models.Models;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(artist => artist.ArtistId);

        builder.Property(artist => artist.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}