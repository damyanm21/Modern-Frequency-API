namespace ModernFrequency.Business.Models.DTOs.Track
{
    public class TrackUpdateDTO
    {
        public int TrackId { get; set; }

        public string Title { get; set; }

        public int DurationInSeconds { get; set; }

        // Foreign key for the Album
        public int AlbumId { get; set; }
    }
}
