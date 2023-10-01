using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Business.Models.DTOs.Artist
{
    public class ArtistUpdateDTO
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
        public Genre? Genre { get; set; }
    }
}
