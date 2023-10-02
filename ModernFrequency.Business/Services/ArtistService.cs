using AutoMapper;
using ModernFrequency.Business.Abstraction.Services;
using ModernFrequency.Business.Models.DTOs.Artist;
using ModernFrequency.Business.Models.Helpers.ResponseResult;
using ModernFrequency.Data.Abstraction.Repositories;
using ModernFrequency.Data.Models.Models;
using System.Net;
using static ModernFrequency.Business.Models.Utilities.Constants;

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

        public async Task<ResponseModel> UpdateArtistAsync(ArtistUpdateDTO artist)
        {
            var artistEntity = await _artistRepository.GetByIdAsync(artist.ArtistId);
            
            if (artistEntity == null) 
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            _artistRepository.Update(artistEntity);
            await _artistRepository.SaveChangesAsync();

            return HttpResponseHelper.Success(HttpStatusCode.OK, artist);
        }

        public async Task<ResponseModel> DeleteArtistAsync(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);

            if (artist == null)
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            _artistRepository.Delete(artist);
            await _artistRepository.SaveChangesAsync();

            return HttpResponseHelper.Success(HttpStatusCode.OK);
        }
    }
}
