using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using Mac.VideoApplication2021.BuinessLogic;
using Mac.VideoApplication2021.Models;
using Microsoft.VisualBasic;

namespace Mac.VideoApplication2021.UI
{
    internal class Menu
    {

        private readonly VideoManager _videoManager;

        public Menu()
        {
            _videoManager = new VideoManager();
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
                        _videoManager.DeleteVideo();
                        break;
                    case 5:
                        SearchVideo();
                        break;
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
            //call service to create video
            var video = new Video
            {
                Title = videoName,
                StoryLine = videoStoryLine
            };
            video = _videoManager.Create(video);
            Print($"Video with following properties created. Id: {video.Id.Value} Name: {video.Title}. Storyline: {video.StoryLine}");
            PrintNewLine();
        }

        private void ReadAllVideos()
        {
            foreach (var video in _videoManager.Read())
            {
                Print($"Id: {video.Id}, title: {video.Title}, story line: {video.StoryLine}, release date: {video.StoryLine}");
            }
        }

        private void UpdateVideo()
        {
            var video = FindVideoById();
            Print("new title: ");
            video.Title = Console.ReadLine();
            
            Print("New StoryLine ");
            video.StoryLine = Console.ReadLine();
            
            var updatedVideo = _videoManager.Update(video);
            Print($"Video with id {updatedVideo.Id}, new name: {updatedVideo.Title}, new story line: {updatedVideo.StoryLine}");
        }

        private void SearchVideo()
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
        }

        private Video FindVideoById()
        {
            Print("Type in id to search for");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Print("Try again");
            }

            foreach (var video in videos)
            {
                if (video.Id == id)
                {
                    return video;
                }
            }return null;
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

        private int GetVideoSearch()
        {
            var selectionString = Console.ReadLine();
            int selection;
            if (int.TryParse(selectionString, out selection))
            {
                return selection;
            }

            return -1;
        }
    }
}