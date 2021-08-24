using System.Collections.Generic;
using System.Linq;
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
            var list = _repo.FindAll();
            var orderedEnumerable = list.OrderBy(video => video.ReleaseDate);

            return orderedEnumerable.ToList();
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