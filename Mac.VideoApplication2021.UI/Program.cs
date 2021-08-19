using System;
using System.ComponentModel.Design;

namespace Mac.VideoApplication2021.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            menu.Start();
            Console.ReadLine();
        }
    }
}