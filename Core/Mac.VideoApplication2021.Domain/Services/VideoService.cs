using System.Collections.Generic;
using Mac.VideoApplication2021.Core.IServices;
using Mac.VideoApplication2021.Core.Models;
using Mac.VideoApplication2021.Domain.IRepositories;

namespace Mac.VideoApplication2021.Domain.Services
{
    public class VideoService : IVideoService
    {
        private IVideoRepository _repo;

        public VideoService(IVideoRepository repo)
        {
            _repo = repo;
        }
        public Video Create(Video video)
        {
            return _repo.Add(video);
        }

        public List<Video> ReadAll()
        {
            return _repo.FindAll();
        }

        public Video ReadById(int id)
        {
            return _repo.ReadById(id);
        }

        public Video Update(Video videoUpdate)
        {
            return _repo.UpdateVideo(videoUpdate);
        }

        public void Delete(int id)
        {
            _repo.DeleteVideo(id);
        }
    }
}