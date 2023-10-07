using AutoMapper;
using ModernFrequency.Business.Models.DTOs.Album;
using ModernFrequency.Business.Models.Helpers.ResponseResult;
using ModernFrequency.Data.Abstraction.Repositories;
using static ModernFrequency.Business.Models.Utilities.Constants;
using System.Net;
using ModernFrequency.Data.Models.Models;
using ModernFrequency.Business.Abstraction.Services;
using ModernFrequency.Business.Models.DTOs.Track;

namespace ModernFrequency.Business.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;

        public AlbumService(IAlbumRepository albumRepository, IMapper mapper, ITrackRepository trackRepository)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
            _trackRepository = trackRepository;
        }

        public async Task<ICollection<AlbumGetDTO>> GetAllAlbumsAsync()
        {
            var albums = await _albumRepository.All();
            var albumDtos = _mapper.Map<ICollection<AlbumGetDTO>>(albums);

            foreach (var albumDto in albumDtos)
            {
                var tracks = await _trackRepository.GetTracksByAlbumId(albumDto.AlbumId);
                albumDto.Tracks = _mapper.Map<ICollection<TrackIncludeDTO>>(tracks);
            }

            return albumDtos;
        }

        public async Task<ResponseModel> GetAlbumByIdAsync(int id)
        {
            var album = await _albumRepository.GetByIdAsync(id);

            if (album == null)
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            var albumDTO = _mapper.Map<AlbumGetDTO>(album);

            var tracks = await _trackRepository.GetTracksByAlbumId(id);
            albumDTO.Tracks = _mapper.Map<ICollection<TrackIncludeDTO>>(tracks);

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
            var albumDTO = await _albumRepository.GetByIdAsync(album.AlbumId);

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
