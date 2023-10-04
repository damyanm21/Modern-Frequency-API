using ModernFrequency.Business.Models.DTOs.Album;
using ModernFrequency.Business.Models.DTOs.AlbumArtist;
using ModernFrequency.Data.Models.Models.Enums;

namespace ModernFrequency.Business.Models.DTOs.Artist
{
    public class ArtistGetDTO
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public Genre? Genre { get; set; }
        public ICollection<AlbumPostDTO> Albums { get; set; }
    }
}
