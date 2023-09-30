using ModernFrequency.Business.Models.DTOs;

namespace ModernFrequency.Business.Abstraction.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<ArtistDTO>> GetAllArtistsAsync();
        Task<ArtistDTO> GetArtistByIdAsync(int id);
        Task CreateArtistAsync(ArtistDTO artist);
        Task UpdateArtistAsync(ArtistDTO artist);
        Task DeleteArtistAsync(int id);
    }
}
