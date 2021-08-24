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
        
        List<Video> videos = new List<Video>();
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

        private void DeleteVideo(int idDelete)
        {
            Print("Type the id of the video you want to delete: ");
            idDelete = int.Parse(Console.ReadLine());
            
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
                Print($"Id: {video.Id}, title: {video.Title}, story line: {video.StoryLine}, release date: {video.StoryLine}");
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

            _service.Update(videoToUpdate);
            Print($"Video with id {videoToUpdate.Id}, new name: {videoToUpdate.Title}, new storyline: {newStoryLine}");
        }

        /*private void SearchVideo()
        { 
            Print(StringConstants.WhatToSearchFor);

            int choice;

            while ((choice = GetVideoSearch()) != 0)
            {
                if (choice == 1)
                {
                    Print("Type id to search for");
                    var idToSearchFor = Console.ReadLine();
                    Print($"You searched for id {idToSearchFor}");
                }
                else if (choice == -1)
                {
                    Print(StringConstants.PleaseSelectCorrectSearchOptions);
                }
            }
        }*/

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

        private int GetVideoSearch(string selectionString)
        {
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }
            else return -1;
        }
    }
}