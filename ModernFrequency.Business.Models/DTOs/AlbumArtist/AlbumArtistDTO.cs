using ModernFrequency.Business.Models.DTOs.Album;
using ModernFrequency.Business.Models.DTOs.Artist;

namespace ModernFrequency.Business.Models.DTOs.AlbumArtist
{
    public class AlbumArtistDTO
    {
        public int AlbumId { get; set; }
        public AlbumDTO Album { get; set; }

        public int ArtistId { get; set; }
        public ArtistPostDTO Artist { get; set; }
    }
}
