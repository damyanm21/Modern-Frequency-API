﻿using ModernFrequency.Business.Models.DTOs.AlbumArtist;
using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Business.Models.DTOs.Artist
{
    public class ArtistGetDTO
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<AlbumArtistDTO> Albums { get; set; }
    }
}