namespace ModernFrequency.Business.Models.DTOs.Track
{
    public class TrackPostDTO
    {
        public string Title { get; set; }

        public int DurationInSeconds { get; set; }

        // Foreign key for the Album
        public int AlbumId { get; set; }
    }
}
