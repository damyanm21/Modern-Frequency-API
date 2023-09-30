namespace ModernFrequency.Business.Models.DTOs
{
    public class AlbumArtistDTO
    {
        public int AlbumId { get; set; }
        public AlbumDTO Album { get; set; }

        public int ArtistId { get; set; }
        public ArtistDTO Artist { get; set; }
    }
}
