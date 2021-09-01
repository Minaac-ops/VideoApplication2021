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
        public Video Create(Video video)
        {
            
            return _videoService.Create(video);
        }

        [HttpGet]
        public List<Video> getAll()
        {
            return _videoService.ReadAll();
        }

        [HttpPut]
        public Video Update(Video videoToUpdate)
        {
            return _videoService.Update(videoToUpdate);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _videoService.Delete(id);
        }
    }
}