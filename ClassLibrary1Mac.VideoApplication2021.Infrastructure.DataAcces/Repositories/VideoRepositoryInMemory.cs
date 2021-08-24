using System;
using System.Collections.Generic;
using Mac.VideoApplication2021.Core.Models;
using Mac.VideoApplication2021.Domain.IRepositories;

namespace ClassLibrary1Mac.VideoApplication2021.Infrastructure.DataAcces.Repositories
{
    public class VideoRepositoryInMemory : IVideoRepository
    {

        private static List<Video> _videosTable = new List<Video>();
        private static int _id = 1;
        
        public Video Add(Video video)
        {
            video.Id = _id++;
            _videosTable.Add(video);
            return video;
        }

        public IEnumerable<Video> FindAll()
        {
            return _videosTable;
        }

        public Video ReadById(int id)
        {
            foreach (var video in _videosTable)
            {
                if (video.Id == id)
                {
                    return video;
                }
            }
            return null;
        }

        public Video UpdateVideo(Video videoUpdate)
        {
            var video = this.ReadById(videoUpdate.Id);
            if (video != null)
            {
                video.Title = videoUpdate.Title;
                video.StoryLine = videoUpdate.StoryLine;
                return video;
            }
            return null;
        }

        public void DeleteVideo(int id)
        {
            var viedoFound = this.ReadById(id);
            if (viedoFound != null)
            {
                _videosTable.Remove(viedoFound);
            }
        }
    }
}