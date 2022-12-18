using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        public void UserInput(int level, Display display)
        {
            Console.Write("Command:");
            HandleInput(Console.ReadLine(), level, display);
        }

        private void HandleInput(string command, int level, Display display)
        {
            if (levels[level].Commands.Contains(command))
            {
                switch (command)
                {
                    case "Inventory":
                        display.LevelHandler.Commands = new string[] { "Press a key to exit inventory" };
                        display.Screen(true);
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Incorrect command, please check the avaible commands above.");
                UserInput(level, display);
            }

            Console.WriteLine();
        }
    }
}
