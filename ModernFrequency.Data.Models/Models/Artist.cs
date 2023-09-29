using System.ComponentModel.DataAnnotations;

namespace ModernFrequency.Data.Models.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        // Navigation property for Albums
        public ICollection<AlbumArtist> Albums { get; set; }
    }
}
