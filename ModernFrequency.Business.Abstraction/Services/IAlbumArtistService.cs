using ModernFrequency.Business.Models.DTOs;

namespace ModernFrequency.Business.Abstraction.Services
{
    public interface IAlbumArtistService
    {
        Task<IEnumerable<AlbumArtistDTO>> GetAllAlbumArtistsAsync();
        Task<AlbumArtistDTO> GetAlbumArtistByIdAsync(int id);
        Task CreateAlbumArtistAsync(AlbumArtistDTO albumArtist);
        Task UpdateAlbumArtistAsync(AlbumArtistDTO albumArtist);
        Task DeleteAlbumArtistAsync(int id);
    }
}
