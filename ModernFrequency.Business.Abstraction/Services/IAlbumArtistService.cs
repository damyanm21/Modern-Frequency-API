using ModernFrequency.Business.Models.DTOs.AlbumArtist;

namespace ModernFrequency.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing album artists.
    /// </summary>
    public interface IAlbumArtistService
    {
        /// <summary>
        /// Retrieves all album artists asynchronously.
        /// </summary>
        /// <returns>A collection of album artist DTOs.</returns>
        Task<IEnumerable<AlbumArtistDTO>> GetAllAlbumArtistsAsync();

        /// <summary>
        /// Retrieves an album artist by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the album artist.</param>
        /// <returns>The album artist DTO, or null if not found.</returns>
        Task<AlbumArtistDTO> GetAlbumArtistByIdAsync(int id);

        /// <summary>
        /// Creates a new album artist asynchronously.
        /// </summary>
        /// <param name="albumArtist">The album artist DTO to create.</param>
        Task CreateAlbumArtistAsync(AlbumArtistDTO albumArtist);

        /// <summary>
        /// Updates an existing album artist asynchronously.
        /// </summary>
        /// <param name="albumArtist">The album artist DTO to update.</param>
        Task UpdateAlbumArtistAsync(AlbumArtistDTO albumArtist);

        /// <summary>
        /// Deletes an album artist by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the album artist to delete.</param>
        Task DeleteAlbumArtistAsync(int id);
    }
}
