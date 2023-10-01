using ModernFrequency.Data.Models.Models.Enums;

namespace ModernFrequency.Business.Models.DTOs.Artist
{
    public class ArtistPostDTO
    {
        public string Name { get; set; }
        public Genre? Genre { get; set; }
    }
}
