using AutoMapper;
using ModernFrequency.Business.Models.DTOs.Album;
using ModernFrequency.Business.Models.Helpers.ResponseResult;
using ModernFrequency.Data.Abstraction.Repositories;
using static ModernFrequency.Business.Models.Utilities.Constants;
using System.Net;
using ModernFrequency.Data.Models.Models;
using ModernFrequency.Business.Abstraction.Services;

namespace ModernFrequency.Business.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<AlbumGetDTO>> GetAllAlbumsAsync()
        {
            var albums = await _albumRepository.All();
            return _mapper.Map<ICollection<AlbumGetDTO>>(albums);
        }

        public async Task<ResponseModel> GetAlbumByIdAsync(int id)
        {
            var album = await _albumRepository.GetByIdAsync(id);
            var albumDTO = _mapper.Map<AlbumGetDTO>(album);

            if (id == null)
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            return HttpResponseHelper.Success(HttpStatusCode.OK, albumDTO);
        }

        public async Task<ResponseModel> CreateAlbumAsync(AlbumPostDTO albumDTO)
        {
            var album = _mapper.Map<Album>(albumDTO);
            await _albumRepository.AddAsync(album);
            await _albumRepository.SaveChangesAsync();

            return HttpResponseHelper.Success(HttpStatusCode.OK, albumDTO);
        }

        public async Task<ResponseModel> UpdateAlbumAsync(AlbumUpdateDTO album)
        {
            var albumDTO = await _albumRepository.GetByIdAsync(album.ArtistId);

            if (albumDTO == null)
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            _albumRepository.Update(albumDTO);
            await _albumRepository.SaveChangesAsync();

            return HttpResponseHelper.Success(HttpStatusCode.OK, album);
        }

        public async Task<ResponseModel> DeleteAlbumAsync(int id)
        {
            var album = await _albumRepository.GetByIdAsync(id);

            if (album == null)
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            _albumRepository.Delete(album);
            await _albumRepository.SaveChangesAsync();

            return HttpResponseHelper.Success(HttpStatusCode.OK);
        }
    }
}
