using AutoMapper;
using ModernFrequency.Business.Abstraction.Services;
using ModernFrequency.Business.Models.DTOs.Album;
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
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper, IAlbumRepository albumRepository)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _albumRepository = albumRepository;
        }

        public async Task<ICollection<ArtistGetDTO>> GetAllArtistsAsync()
        {
            var artists = await _artistRepository.All();
            var artistsWithAlbums = new List<Artist>();

            foreach (var artist in artists)
            {
                var albums = await _albumRepository.GetAlbumsByArtistId(artist.ArtistId);
                artist.Albums = albums.Select(album => new AlbumArtist
                {
                    Album = album,
                    Artist = artist
                }).ToList();

                artistsWithAlbums.Add(artist);
            }

            return _mapper.Map<ICollection<ArtistGetDTO>>(artistsWithAlbums);
        }

        public async Task<ResponseModel> GetArtistByIdAsync(int id)
        {
            var artist = await _artistRepository.GetByIdAsync(id);
            var albums = await _albumRepository.GetAlbumsByArtistId(id);

            if (artist == null)
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            var artistDTO = new ArtistGetDTO
            {
                ArtistId = artist.ArtistId,
                Name = artist.Name,
                Genre = artist.Genre,
                Albums = albums.Select(album => new AlbumIncludeDTO
                {
                    Title = album.Title,
                    ReleaseYear = album.ReleaseYear
                }).ToList()
            };

            return HttpResponseHelper.Success(HttpStatusCode.OK, artistDTO);
        }

        public async Task<ResponseModel> CreateArtistAsync(ArtistPostDTO artistDto)
        {
            var artist = _mapper.Map<Artist>(artistDto);
            await _artistRepository.AddAsync(artist);
            await _artistRepository.SaveChangesAsync(); 

            return HttpResponseHelper.Success(HttpStatusCode.OK, artistDto);
        }

        public async Task<ResponseModel> UpdateArtistAsync(ArtistUpdateDTO artist)
        {
            var artistDTO = await _artistRepository.GetByIdAsync(artist.ArtistId);
            
            if (artistDTO == null) 
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            _artistRepository.Update(artistDTO);
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
