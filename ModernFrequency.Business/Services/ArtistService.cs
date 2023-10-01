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

        public async Task<IEnumerable<ArtistGetDTO>> GetAllArtistsAsync()
        {
            var artists = await _artistRepository.All();
            return _mapper.Map<IEnumerable<ArtistGetDTO>>(artists);
        }

        public async Task<ArtistGetDTO> GetArtistByIdAsync(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            return _mapper.Map<ArtistGetDTO>(artist);
        }

        public async Task CreateArtistAsync(ArtistPostDTO artistDto)
        {
            var artist = _mapper.Map<Artist>(artistDto);
            await _artistRepository.AddAsync(artist);
            await _artistRepository.SaveChangesAsync(); 
        }

        public async Task UpdateArtistAsync(ArtistUpdateDTO artist)
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
