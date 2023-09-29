using System.ComponentModel.DataAnnotations;

namespace ModernFrequency.Data.Models.Models
{
    public class Track
    {
        public int TrackId { get; set; }

        public string Title { get; set; }

        public int DurationInSeconds { get; set; }

        // Foreign key for the Album
        public int AlbumId { get; set; }

        // Navigation property for the Album
        public Album Album { get; set; }
    }
}
