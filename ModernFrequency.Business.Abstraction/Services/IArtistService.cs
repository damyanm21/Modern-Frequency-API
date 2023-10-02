using ModernFrequency.Business.Models.DTOs.Artist;
using ModernFrequency.Business.Models.Helpers.ResponseResult;

namespace ModernFrequency.Business.Abstraction.Services
{
    /// <summary>
    /// Represents a service for managing artists.
    /// </summary>
    public interface IArtistService
    {
        /// <summary>
        /// Gets all artists asynchronously.
        /// </summary>
        /// <returns>An enumerable collection of artist DTOs.</returns>
        Task<IEnumerable<ArtistGetDTO>> GetAllArtistsAsync();

        /// <summary>
        /// Gets an artist by their ID asynchronously.
        /// </summary>
        /// <param name="id">The unique ID of the artist.</param>
        /// <returns>The artist DTO if found; otherwise, null.</returns>
        Task<ArtistGetDTO> GetArtistByIdAsync(int id);

        /// <summary>
        /// Creates a new artist asynchronously.
        /// </summary>
        /// <param name="artist">The artist DTO to create.</param>
        Task CreateArtistAsync(ArtistPostDTO artist);

        /// <summary>
        /// Updates an existing artist asynchronously.
        /// </summary>
        /// <param name="artist">The artist DTO to update.</param>
        Task<ResponseModel> UpdateArtistAsync(ArtistUpdateDTO artist);

        /// <summary>
        /// Deletes an artist by their ID asynchronously.
        /// </summary>
        /// <param name="id">The unique ID of the artist to delete.</param>
        Task<ResponseModel> DeleteArtistAsync(int id);
    }
}
