using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Mac.VideoApplication2021.UI
{
    internal class Menu
    {
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
                        ListAllVideos();
                        break;
                    case 3:
                        UpdateVideo();
                        break;
                    case 4:
                        DeleteVideo();
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

        private void UpdateVideo()
        {
            throw new NotImplementedException();
        }

        private void DeleteVideo()
        {
            throw new NotImplementedException();
        }

        private void ListAllVideos()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            Console.Clear();
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

        private void CreateVideo()
        {
            PrintNewLine();
            Print(StringConstants.CreateVideoGreeting);
            Print(StringConstants.VideoName);
            var videoName = Console.ReadLine();
            Print(StringConstants.videoStoryLine);
            var videoStoryLine = Console.ReadLine();
            //call service to create video
            Print($"Video with following properties created. Name: {videoName}. Storyline: {videoStoryLine}");
            PrintNewLine();
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