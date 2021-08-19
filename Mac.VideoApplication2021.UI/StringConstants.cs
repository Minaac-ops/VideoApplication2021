using System;

namespace Mac.VideoApplication2021.UI
{
    public class StringConstants
    {
        public static readonly string welcomeGreeting = "Welcome to the Video App";
        public static readonly string PleaseSelectMain = "Select one of the items below";
        
        //  CRUD
        public static readonly string CreateVideoMenuText = "Select 1 to create new video";
        public static readonly string ShowAllVideosMenuText = "Select 2 to see all videos";
        public static readonly string UpdateVideoMenuText = "Select 3 to update a video";
        public static readonly string DeleteVideoMenuText = "Select 4 to delete a video";
        public static readonly string SearchVideoMenuText = "Select 5 to search a video";
        
        public static readonly string exitMainMenu = "select 0 to exit";
        
        public static readonly string PleaseSelectCorrectItem = "Please select a number between 0-5";
        
        //  CREATE VIDEO MENU
        public static readonly string CreateVideoGreeting = "Create video";
        public static readonly string VideoName = "Type video name (with more than two characters and less than 40)";
        public static readonly  string videoStoryLine = "Type video storyline";
        
        public static readonly string WhatToSearchFor = "Please decide what to search for (1 - id, 2 - title, 0 - to go back)";
        
        public static readonly string PleaseSelectCorrectSearchOptions = "Please select between 0-2";
    }
    
}