using System.Collections.Generic;
using Mac.VideoApplication2021.Core.IServices;
using Mac.VideoApplication2021.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mac.VideoApplication2021.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly IVideoService _videoService;
        
        public VideosController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpPost]
        public ActionResult<Video> Create([FromBody] Video video)
        {
            if (string.IsNullOrEmpty(video.Title))
            {
                return BadRequest("Firstname is required for creating a new video!");
            }
            return _videoService.Create(video);
        }

        [HttpGet]
        public ActionResult<List<Video>> getAll()
        {
            if (_videoService.ReadAll() == null)
            {
                return BadRequest("There is no videos in the list yet.");
            }
            return _videoService.ReadAll();
        }

        [HttpPut]
        public Video Update(Video videoToUpdate)
        {
            return _videoService.Update(videoToUpdate);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _videoService.Delete(id);
        }
    }
}