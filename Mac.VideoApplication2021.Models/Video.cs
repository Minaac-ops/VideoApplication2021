using System;

namespace Mac.VideoApplication2021.Models
{
    public class Video
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string StoryLine { get; set; }
    }
}