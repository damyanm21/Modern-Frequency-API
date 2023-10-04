using Microsoft.AspNetCore.Mvc;
using ModernFrequency.Business.Abstraction.Services;
using ModernFrequency.Business.Models.DTOs.Album;
using ModernFrequency.Business.Models.Helpers.ResponseResult;
using System.Net;

namespace ModernFrequency.Presentation.API.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAllAlbums()
        {
            var albums = await _albumService.GetAllAlbumsAsync();
            var result = HttpResponseHelper.Success(HttpStatusCode.OK, albums);

            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbumById(int id)
        {
            var album = await _albumService.GetAlbumByIdAsync(id);

            return StatusCode(album.HttpStatusCode, album);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAlbum([FromBody] AlbumPostDTO album)
        {
            var result = await _albumService.CreateAlbumAsync(album);

            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbum(AlbumUpdateDTO album)
        {
            var result = await _albumService.UpdateAlbumAsync(album);

            return StatusCode(result.HttpStatusCode, result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var result = await _albumService.DeleteAlbumAsync(id);

            return StatusCode(result.HttpStatusCode, result);
        }
    }
}
