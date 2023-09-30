using AutoMapper;
using ModernFrequency.Business.Abstraction.Services;
using ModernFrequency.Business.Models.DTOs.Artist;
using ModernFrequency.Data.Abstraction.Repositories;
using ModernFrequency.Data.Models.Models;

namespace ModernFrequency.Business.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtistDTO>> GetAllArtistsAsync()
        {
            var artists = await _artistRepository.All();
            return _mapper.Map<IEnumerable<ArtistDTO>>(artists);
        }

        public async Task<ArtistDTO> GetArtistByIdAsync(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            return _mapper.Map<ArtistDTO>(artist);
        }

        public async Task CreateArtistAsync(ArtistDTO artistDto)
        {
            var artist = _mapper.Map<Artist>(artistDto);
            await _artistRepository.AddAsync(artist);
            await _artistRepository.SaveChangesAsync(); 
        }

        public async Task UpdateArtistAsync(ArtistDTO artist)
        {
            var artistEntity = _mapper.Map<Artist>(artist);
            _artistRepository.Update(artistEntity);
            await _artistRepository.SaveChangesAsync();
        }

        public async Task DeleteArtistAsync(int id)
        {
            await _artistRepository.DeleteAsync(id);
            await _artistRepository.SaveChangesAsync();
        }
    }
}
