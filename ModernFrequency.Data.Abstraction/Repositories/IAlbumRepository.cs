using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface for managing Album entities.
    /// This interface inherits IRepository<Album>
    /// </summary>
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<IEnumerable<Album>> GetAlbumsByArtistId(int artistId);
    }
}
