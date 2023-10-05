using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernFrequency.Business.Abstraction.Services;
using ModernFrequency.Business.Models.DTOs.Album;
using ModernFrequency.Business.Models.DTOs.Track;
using ModernFrequency.Business.Models.Helpers.ResponseResult;
using ModernFrequency.Business.Services;
using System.Net;

namespace ModernFrequency.Presentation.API.Controllers
{
    [Route("api/tracks")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ITrackService _trackService;
        public TrackController(ITrackService trackService)
        {
            _trackService = trackService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAllTracks()
        {
            var tracks = await _trackService.GetAllTracksAsync();
            var result = HttpResponseHelper.Success(HttpStatusCode.OK, tracks);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrackById(int id)
        {
            var track = await _trackService.GetTrackByIdAsync(id);

            return StatusCode(track.HttpStatusCode, track);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrack([FromBody] TrackPostDTO track)
        {
            var result = await _trackService.CreateTrackAsync(track);

            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrack(TrackUpdateDTO track)
        {
            var result = await _trackService.UpdateTrackAsync(track);

            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var result = await _trackService.DeleteTrackAsync(id);

            return StatusCode(result.HttpStatusCode, result);
        }
    }
}
