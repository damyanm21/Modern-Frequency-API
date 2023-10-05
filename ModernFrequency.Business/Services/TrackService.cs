using AutoMapper;
using ModernFrequency.Business.Abstraction.Services;
using ModernFrequency.Business.Models.DTOs.Album;
using ModernFrequency.Business.Models.DTOs.Track;
using ModernFrequency.Business.Models.Helpers.ResponseResult;
using ModernFrequency.Data.Abstraction.Repositories;
using ModernFrequency.Data.Models.Models;
using System.Net;
using static ModernFrequency.Business.Models.Utilities.Constants;

namespace ModernFrequency.Business.Services
{
    public class TrackService : ITrackService
    {
        private readonly ITrackRepository _trackRepository;
        private readonly IMapper _mapper;

        public TrackService(ITrackRepository trackRepository, IMapper mapper)
        {
            _trackRepository = trackRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<TrackGetDTO>> GetAllTracksAsync()
        {
            var albums = await _trackRepository.All();
            return _mapper.Map<ICollection<TrackGetDTO>>(albums);
        }

        public async Task<ResponseModel> GetTrackByIdAsync(int id)
        {
            var track = await _trackRepository.GetByIdAsync(id);
            var trackDTO = _mapper.Map<TrackGetDTO>(track);

            if (id == null)
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            return HttpResponseHelper.Success(HttpStatusCode.OK, trackDTO);
        }

        public async Task<ResponseModel> CreateTrackAsync(TrackPostDTO trackDTO)
        {
            var track = _mapper.Map<Track>(trackDTO);
            await _trackRepository.AddAsync(track);
            await _trackRepository.SaveChangesAsync();

            return HttpResponseHelper.Success(HttpStatusCode.OK, trackDTO);
        }

        public async Task<ResponseModel> UpdateTrackAsync(TrackUpdateDTO track)
        {
            var trackDTO = await _trackRepository.GetByIdAsync(track.TrackId);

            if (trackDTO == null)
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            _trackRepository.Update(trackDTO);
            await _trackRepository.SaveChangesAsync();

            return HttpResponseHelper.Success(HttpStatusCode.OK, track);
        }

        public async Task<ResponseModel> DeleteTrackAsync(int id)
        {
            var track = await _trackRepository.GetByIdAsync(id);

            if (track == null)
            {
                return HttpResponseHelper.Error(HttpStatusCode.NotFound, IdNotFound);
            }

            _trackRepository.Delete(track);
            await _trackRepository.SaveChangesAsync();

            return HttpResponseHelper.Success(HttpStatusCode.OK);
        }
    }
}
