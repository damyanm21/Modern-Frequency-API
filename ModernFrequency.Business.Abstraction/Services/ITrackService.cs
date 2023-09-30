using ModernFrequency.Business.Models.DTOs.Track;

namespace ModernFrequency.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing tracks.
    /// </summary>
    public interface ITrackService
    {
        /// <summary>
        /// Retrieves all tracks asynchronously.
        /// </summary>
        /// <returns>A collection of track DTOs.</returns>
        Task<IEnumerable<TrackDTO>> GetAllTracksAsync();

        /// <summary>
        /// Retrieves a track by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the track.</param>
        /// <returns>The track DTO if found; otherwise, null.</returns>
        Task<TrackDTO> GetTrackByIdAsync(int id);

        /// <summary>
        /// Creates a new track asynchronously.
        /// </summary>
        /// <param name="track">The track DTO to create.</param>
        Task CreateTrackAsync(TrackDTO track);

        /// <summary>
        /// Updates an existing track asynchronously.
        /// </summary>
        /// <param name="track">The track DTO to update.</param>
        Task UpdateTrackAsync(TrackDTO track);

        /// <summary>
        /// Deletes a track by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the track to delete.</param>
        Task DeleteTrackAsync(int id);
    }
}
