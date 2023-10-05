namespace ModernFrequency.Business.Models.DTOs.Album
{
    public class AlbumPostDTO
    {
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        // Foreign key for the Artist
        public int ArtistId { get; set; }
    }
}
