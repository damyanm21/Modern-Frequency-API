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
        public async Task<ResponseModel> GetArtistById(int id)
        {
            var artist = await _artistService.GetArtistByIdAsync(id);
            var result = HttpResponseHelper.Success(HttpStatusCode.OK, artist);

            return result;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateArtist([FromBody] ArtistDTO artist)
        {
            await _artistService.CreateArtistAsync(artist);
            var result = HttpResponseHelper.Success(HttpStatusCode.Created, artist);

            return result;
        }


        [HttpPut("{id}")]
        public async Task<ResponseModel> UpdateArtist(ArtistDTO artist)
        {
            await _artistService.UpdateArtistAsync(artist);
            var result = HttpResponseHelper.Success(HttpStatusCode.Created, artist);

            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ResponseModel> DeleteArtist(int id)
        {
            await _artistService.DeleteArtistAsync(id);
            var result = HttpResponseHelper.Success(HttpStatusCode.OK);

            return result;
        }
    }
}
