using System;
using System.ComponentModel.Design;
using ClassLibrary1Mac.VideoApplication2021.Infrastructure.DataAcces.Repositories;
using Mac.VideoApplication2021.Core.IServices;
using Mac.VideoApplication2021.Domain.IRepositories;
using Mac.VideoApplication2021.Domain.Services;
using Mac.VideoApplication2021.SQL.Repository;

namespace Mac.VideoApplication2021.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //cheapish DI (Dependency injection)
            //IVideoRepository repo = new VideoRepositoryInMemory();
            IVideoRepository repo = new VideoRepository();
            IVideoService service = new VideoService(repo);
            
            var menu = new Menu(service);
            menu.Start();
        }
    }
}