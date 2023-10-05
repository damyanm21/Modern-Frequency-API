using ModernFrequency.Business.Models.DTOs.Album;
using ModernFrequency.Business.Models.Helpers.ResponseResult;

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
        Task<ICollection<AlbumGetDTO>> GetAllAlbumsAsync();

        /// <summary>
        /// Retrieves an album by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the album to retrieve.</param>
        /// <returns>An asynchronous operation that returns the AlbumDTO with the specified ID.</returns>
        Task<ResponseModel> GetAlbumByIdAsync(int id);

        /// <summary>
        /// Creates a new album asynchronously.
        /// </summary>
        /// <param name="album">The AlbumDTO representing the album to be created.</param>
        /// <returns>An asynchronous operation representing the creation of the album.</returns>
        Task<ResponseModel> CreateAlbumAsync(AlbumPostDTO albumDTO);

        /// <summary>
        /// Updates an existing album asynchronously.
        /// </summary>
        /// <param name="album">The AlbumDTO representing the album to be updated.</param>
        /// <returns>An asynchronous operation representing the update of the album.</returns>
        Task<ResponseModel> UpdateAlbumAsync(AlbumUpdateDTO albumDTO);

        /// <summary>
        /// Deletes an album by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the album to delete.</param>
        /// <returns>An asynchronous operation representing the deletion of the album.</returns>
        Task<ResponseModel> DeleteAlbumAsync(int id);
    }
}
