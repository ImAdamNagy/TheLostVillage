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
                    if (command == "Inventory")
                    {
                        string[] savedcommands = display.AviableCommands;
                        display.LevelHandler.Commands = new string[] { "Press a key to exit inventory" };
                        display.Screen(true);
                        Console.ReadKey();
                        display.LevelHandler.Commands = savedcommands;
                        display.Screen(false);
                        UserInput(level, display, player);
                        break;
                    }                                                      
                    else if (command == "Fight")
                    {
                        Enemy enemy = display.LevelHandler.Enemy;
                        Battle Fight = new Battle(player, enemy);
                        while (!Fight.Over)
                        {
                            Fight.Fight(display);
                            Console.ReadKey();
                        }
                        break;
                    }
                    else if(command=="Give_Talisman")
                    {
                        player.Inventory.RemoveAt(player.Inventory.Count-1);
                        player.Inventory.Add(new Item("Scroll;1;True;9999;0;9999"));
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
