using System.Collections.Generic;
using System.Linq;
using Mac.VideoApplication2021.Core.Models;
using Mac.VideoApplication2021.Domain.IRepositories;
using Mac.VideoApplication2021.SQL.Converter;
using Mac.VideoApplication2021.SQL.Entities;

namespace Mac.VideoApplication2021.SQL.Repository
{
    public class VideoRepository : IVideoRepository
    {
        
        private static List<VideoEntity> _videoTable = new List<VideoEntity>();
        private static int _id = 1;
        private readonly VideoConverter _videoConverter;

        public VideoRepository()
        {
            _videoConverter = new VideoConverter();
        }
        
        public Video Add(Video video)
        {
            var videoEntity = _videoConverter.Convert(video);
            videoEntity.Id = _id++;
            _videoTable.Add(videoEntity);
            return _videoConverter.Convert(videoEntity);
        }

        public List<Video> FindAll()
        {
            var listOfVideos = new List<Video>();
            foreach (var videoEntity in _videoTable)
            {
                listOfVideos.Add(_videoConverter.Convert(videoEntity));
            }
            return listOfVideos;
        }

        public Video ReadById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Video UpdateVideo(Video videoUpdate)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteVideo(int videoDelete)
        {
            throw new System.NotImplementedException();
        }
    }
}