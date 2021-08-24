using System.Collections.Generic;
using Mac.VideoApplication2021.Core.Models;

namespace Mac.VideoApplication2021.Core.IServices
{
    public interface IVideoService
    {
        Video Create(Video video);

        List<Video> ReadAll();

        Video ReadById(int id);

        Video Update(Video videoUpdate);

        void Delete(int id);
    }
}