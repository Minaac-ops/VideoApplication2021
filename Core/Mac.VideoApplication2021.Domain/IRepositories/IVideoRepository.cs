using System.Collections.Generic;
using Mac.VideoApplication2021.Core.Models;

namespace Mac.VideoApplication2021.Domain.IRepositories
{
    public interface IVideoRepository
    {
        private static List<Video> _fakeDbVideos = new List<Video>();
        private static int _id = 1;
        
        Video Add(Video video);
        List<Video> FindAll();

        Video ReadById(int id);

        Video UpdateVideo(Video videoUpdate);

        void DeleteVideo(int videoDelete);
    }
}