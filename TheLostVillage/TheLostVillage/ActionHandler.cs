using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace TheLostVillage
{
    public class ActionHandler
    {
        public List<LevelHandler> levels = new List<LevelHandler>();
        public ActionHandler()
        {
            foreach (var item in File.ReadAllLines("levels.txt"))
            {
               levels.Add(new LevelHandler(item));
            }
        }
        public void UserInput(int level, Display display, Player player)
        {
            Console.Write("Command:");
            HandleInput(Console.ReadLine(), level, display, player);
        }

        private void HandleInput(string command, int level, Display display, Player player)
        {
            if (levels[level].Commands.Contains(command))
            {
                while (command != "Travel")
                {
                    switch (command)
                    {
                        case "Inventory":
                            string[] savedcommands = display.AviableCommands;
                            display.LevelHandler.Commands = new string[] { "Press a key to exit inventory" };
                            display.Screen(true);
                            Console.ReadKey();
                            display.LevelHandler.Commands = savedcommands;
                            display.Screen(false);
                            UserInput(level, display, player);
                            break;
                        case "Fight":
                            Battle Fight = new Battle(player, display.LevelHandler.Enemy);
                            Fight.Fight(display);
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Incorrect command, please check the avaible commands above.");
                UserInput(level, display,player);
            }

            Console.WriteLine();
        }
    }
}
