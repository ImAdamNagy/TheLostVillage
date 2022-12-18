using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    class Menu
    {
        private int Index;
        private string[] Options;
        private string Title;

        public Menu(string title, string[] options)
        {
            Title = title;
            Options = options;
            Index = 0;
        }

        private void DisplayTheOptionsAndTheTitle()
        {
            Display DisplayHelper = new Display();
            int firstLineWidth = Title.Split('\n')[0].Length;
            int screenWidth = firstLineWidth;
            Console.WindowWidth = firstLineWidth + 5;
            Console.WriteLine(Title);
            for (int i = 0; i < Options.Length; i++)
            {
                string markerStart;
                string markerEnd;

                if (i == Index)
                {
                    markerStart = "-- ";
                    markerEnd = " --";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    markerStart = " ";
                    markerEnd = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                string selectedoption = markerStart + Options[i] + markerEnd;
                Console.WriteLine($"\n{String.Format("{0," + ((Console.WindowWidth / 2) + (selectedoption.Length / 2)) + "}", selectedoption)}");
            }
            Console.ResetColor();
        }
        public string DisplayAboutTheGame()
        {
            string info = "About the game";
            return info;
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayTheOptionsAndTheTitle();
                ConsoleKeyInfo Info = Console.ReadKey(true);
                keyPressed = Info.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Index--;
                    if (Index == -1)
                    {
                        Index = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Index++;
                    if (Index == Options.Length)
                    {
                        Index = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return Index;
        }
        public void ExitGame()
        {
            Environment.Exit(0);
        }
        public void GameInfo()
        {
            Display center = new Display();
            Console.Clear();
            string gameInfo = "\n\n\nYou wake up in the Witch's hut and the witch gives you a list of tasks.\nYou have Five Days to find The Lost Village where people will be able to help the Hungarians Defeat the Turks.\n On the list you can find step by step what you have to do and where to go...";
            string credits = "\n\n\nThis game was made by \n Kinga Kiss \n Péter Dobronay \n Donát Dénes \n Ferenc Török \n Adam Nagy";
            foreach (var item in gameInfo.Split('\n'))
            {
                Console.WriteLine("\n" + center.AlignCenter(item));
            }

            foreach (var item in credits.Split('\n'))
            {
                Console.WriteLine("\n" + center.AlignCenter(item));
            }
            Console.SetWindowSize(161, 41);
        }
    }
}

