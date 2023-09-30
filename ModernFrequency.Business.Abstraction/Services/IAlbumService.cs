using ModernFrequency.Business.Models.DTOs;

namespace ModernFrequency.Business.Abstraction.Services
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDTO>> GetAllAlbumsAsync();
        Task<AlbumDTO> GetAlbumByIdAsync(int id);
        Task CreateAlbumAsync(AlbumDTO artist);
        Task UpdateAlbumAsync(AlbumDTO artist);
        Task DeleteAlbumAsync(int id);
    }
}
