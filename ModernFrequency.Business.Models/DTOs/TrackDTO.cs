namespace ModernFrequency.Business.Models.DTOs
{
    public class TrackDTO
    {
        public int TrackId { get; set; }

        public string Title { get; set; }

        public int DurationInSeconds { get; set; }

        // Foreign key for the Album
        public int AlbumId { get; set; }

        // Navigation property for the Album
        public AlbumDTO Album { get; set; }
    }
}
