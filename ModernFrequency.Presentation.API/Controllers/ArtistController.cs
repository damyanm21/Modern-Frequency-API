using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModernFrequency.Business.Abstraction.Services;
using ModernFrequency.Business.Models.DTOs.Artist;
using ModernFrequency.Business.Models.Helpers.ResponseResult;
using ModernFrequency.Data.Models.Models;
using System.Net;

namespace ModernFrequency.Presentation.API.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAllArtists()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            var result = HttpResponseHelper.Success(HttpStatusCode.OK, artists);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistById(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);

            return StatusCode(artist.HttpStatusCode, artist);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArtist([FromBody] ArtistPostDTO artist)
        {
            await _artistService.CreateArtistAsync(artist);
            var result = HttpResponseHelper.Success(HttpStatusCode.Created, artist);

            return StatusCode(result.HttpStatusCode, result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArtist(ArtistUpdateDTO artist)
        {
            var result = await _artistService.UpdateArtistAsync(artist);

            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var result = await _artistService.DeleteArtistAsync(id);

            return StatusCode(result.HttpStatusCode, result);
        }
    }
}
