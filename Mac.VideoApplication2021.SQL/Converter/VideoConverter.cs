using System;
using Mac.VideoApplication2021.Core.Models;
using Mac.VideoApplication2021.SQL.Entities;

namespace Mac.VideoApplication2021.SQL.Converter
{
    public class VideoConverter
    {
        public Video Convert(VideoEntity entity)
        {
            return new Video()
            {
                Id = entity.Id,
                ReleaseDate = entity.ReleaseDate,
                StoryLine = entity.StoryLine,
                Title = entity.Title
            };
        }

        public VideoEntity Convert(Video video)
        {
            return new VideoEntity()
            {
                Id = video.Id,
                ReleaseDate = video.ReleaseDate,
                StoryLine = video.StoryLine,
                Title = video.Title,
                GenreId = video.Genre.Id
            };
        }
    }
}