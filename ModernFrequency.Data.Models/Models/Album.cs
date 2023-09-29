using System.ComponentModel.DataAnnotations;

namespace ModernFrequency.Data.Models.Models
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        // Foreign key for the Artist
        public int ArtistId { get; set; }

        // Navigation property for the AlbumArtists
        public ICollection<AlbumArtist> AlbumArtists { get; set; }

        // Navigation property for Tracks
        public ICollection<Track> Tracks { get; set; }
    }
}
