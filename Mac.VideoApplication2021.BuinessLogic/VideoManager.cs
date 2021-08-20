using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using Mac.VideoApplication2021.Models;

namespace Mac.VideoApplication2021.BuinessLogic
{
    public class VideoManager
    {
        private static List<Video> _fakeDbVideos = new List<Video>();
        private static int _id = 1;


        public Video Create(Video video)
        {
            video.Id = _id++;
            _fakeDbVideos.Add(video);
            return video;
        }

        public List<Video> Read()
        {
            return _fakeDbVideos;
        }

        public Video Update(Video video)
        {
            string title = video.Title;
            string storyline = video.StoryLine;
            video = new Video
            {
                Title = title,
                StoryLine = storyline,
            };
            return video;
        }

        public void DeleteVideo()
        {
            throw new NotImplementedException();
        }
        }
}