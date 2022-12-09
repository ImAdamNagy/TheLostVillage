﻿using System;
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

        private void DisplayTheOptions()
        {
            int screenWidth = Console.WindowWidth;
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

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayTheOptions();
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
            } while (keyPressed != ConsoleKey.Escape);

            return Index;
        }
    }
}

