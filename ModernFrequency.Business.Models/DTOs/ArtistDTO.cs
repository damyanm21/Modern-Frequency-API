namespace ModernFrequency.Business.Models.DTOs
{
    public class ArtistDTO
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }

        // Include a collection of related albums
        public IEnumerable<AlbumDTO> Albums { get; set; }
    }
}
