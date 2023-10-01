using ModernFrequency.Data.Models.Models.Enums;

namespace ModernFrequency.Business.Models.DTOs.Artist
{
    public class ArtistUpdateDTO
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public Genre? Genre { get; set; }
    }
}
