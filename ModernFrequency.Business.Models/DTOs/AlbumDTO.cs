namespace ModernFrequency.Business.Models.DTOs
{
    public class AlbumDTO
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        // Foreign key for the Artist
        public int ArtistId { get; set; }

        // Navigation property for the AlbumArtists
        public ICollection<AlbumArtistDTO> AlbumArtists { get; set; }

        // Navigation property for Tracks
        public ICollection<TrackDTO> Tracks { get; set; }
    }
}
