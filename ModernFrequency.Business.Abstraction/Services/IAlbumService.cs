using ModernFrequency.Business.Models.DTOs;

namespace ModernFrequency.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing albums.
    /// </summary>
    public interface IAlbumService
    {
        /// <summary>
        /// Retrieves all albums asynchronously.
        /// </summary>
        /// <returns>An asynchronous operation that returns a collection of AlbumDTOs.</returns>
        Task<IEnumerable<AlbumDTO>> GetAllAlbumsAsync();

        /// <summary>
        /// Retrieves an album by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the album to retrieve.</param>
        /// <returns>An asynchronous operation that returns the AlbumDTO with the specified ID.</returns>
        Task<AlbumDTO> GetAlbumByIdAsync(int id);

        /// <summary>
        /// Creates a new album asynchronously.
        /// </summary>
        /// <param name="album">The AlbumDTO representing the album to be created.</param>
        /// <returns>An asynchronous operation representing the creation of the album.</returns>
        Task CreateAlbumAsync(AlbumDTO album);

        /// <summary>
        /// Updates an existing album asynchronously.
        /// </summary>
        /// <param name="album">The AlbumDTO representing the album to be updated.</param>
        /// <returns>An asynchronous operation representing the update of the album.</returns>
        Task UpdateAlbumAsync(AlbumDTO album);

        /// <summary>
        /// Deletes an album by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the album to delete.</param>
        /// <returns>An asynchronous operation representing the deletion of the album.</returns>
        Task DeleteAlbumAsync(int id);
    }
}
