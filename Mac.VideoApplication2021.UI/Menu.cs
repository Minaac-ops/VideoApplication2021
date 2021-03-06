using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Mac.VideoApplication2021.Core.IServices;
using Mac.VideoApplication2021.Core.Models;
using Mac.VideoApplication2021.Domain.Services;
using Microsoft.VisualBasic;

namespace Mac.VideoApplication2021.UI
{
    internal class Menu
    {
        private IVideoService _service;

        public Menu(IVideoService service)
        {
            _service = service;
        }
        
        private static int id = 1;
        
        public void Start()
        {
            ShowWelcomeGreeting();
            StartLoop();
        }

        private void StartLoop()
        {
            int choice;
            while ((choice = GetMainMenuSelection()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        CreateVideo();
                        break;
                    case 2:
                        ReadAllVideos();
                        break;
                    case 3:
                        UpdateVideo();
                        break;
                    case 4:
                        DeleteVideo();
                        break;
                    //case 5:
                        //SearchVideo();
                        //break;
                    case -1:
                        PleaseTryAgain();
                        break;
                }
            }
        }
        
        private void CreateVideo()
        {
            PrintNewLine();
            Print(StringConstants.CreateVideoGreeting);
            
            Print(StringConstants.VideoName);
            var videoName = Console.ReadLine();
            
            Print(StringConstants.videoStoryLine);
            var videoStoryLine = Console.ReadLine();
            
            Print("Type the release date");
            DateTime releaseDate = DateTime.Parse(Console.ReadLine());
            //call service to create video
            var video = new Video()
            {
                Title = videoName,
                StoryLine = videoStoryLine,
                ReleaseDate = releaseDate
            };
            video = _service.Create(video);
            Print($"Video with following properties created. Id: {video.Id} Name: {video.Title}. Storyline: {video.StoryLine}, Release date = {releaseDate}");
            PrintNewLine();
        }
        
        private void ReadAllVideos()
        {
            foreach (var video in _service.ReadAll())
            {
                Print($"Id: {video.Id}, title: {video.Title}, story line: {video.StoryLine}, release date: {video.ReleaseDate}");
            }
        }

        private void UpdateVideo()
        {
            Print("Search for id");
            int idSearch = int.Parse(Console.ReadLine());
            Video videoToUpdate = _service.ReadById(idSearch);

            Print("new title: ");
            string newTitle = Console.ReadLine();
            
            Print("New StoryLine ");
            string newStoryLine = Console.ReadLine();

            _service.Update(new Video()
            {
                Title = newTitle,
                StoryLine = newStoryLine,
                ReleaseDate = videoToUpdate.ReleaseDate,
                Id = videoToUpdate.Id
            });
            Print($"Video with id {videoToUpdate.Id}, new name: {videoToUpdate.Title}, new storyline: {newStoryLine}");
        }
        
        private void DeleteVideo()
        {
            Print("Type the id of the video you want to delete: ");
            var idDelete = int.Parse(Console.ReadLine());
            if (idDelete != null)
            {
                _service.Delete(idDelete);
                Print($"Video with id {idDelete} was succesfully deleted");
            }
        }

        private void PleaseTryAgain()
        {
            Print(StringConstants.PleaseSelectCorrectItem);
        }

        private int GetMainMenuSelection()
        {
            ShowMainMenu();
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            return -1;
        }

        private void ShowMainMenu()
        {
            PrintNewLine();
            Print(StringConstants.PleaseSelectMain);
            PrintNewLine();
            string[] menuItems =
            {
                StringConstants.CreateVideoMenuText,
                StringConstants.ShowAllVideosMenuText,
                StringConstants.UpdateVideoMenuText,
                StringConstants.DeleteVideoMenuText,
                StringConstants.SearchVideoMenuText,
                StringConstants.exitMainMenu,
            };

            for (int i = 0; i < menuItems.Length; i++)
            {
                Print($"{(i + 1)}: {menuItems[i]}");
            }
        }

        private void PrintNewLine()
        {
            Console.WriteLine();
        }

        private void Print(string value)
        {
            Console.WriteLine(value);
        }

        private void ShowWelcomeGreeting()
        {
            Console.WriteLine(StringConstants.welcomeGreeting);
        }
    }
}