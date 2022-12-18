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
        public Player playerdata;
        public ActionHandler()
        {
            foreach (var item in File.ReadAllLines("levels.txt"))
            {
               levels.Add(new LevelHandler(item));
            }
        }
        public void UserInput(int level)
        {
            HandleInput(Console.ReadLine(), level);
        }

        private void HandleInput(string command, int level)
        {
            if (levels[level].Commands.Contains(command))
            {
                switch (command)
                {
                    case "Inventory":
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Nem megfelelő parancs, ellenőrizd az elérhető parancsokat.");
                UserInput(level);
            }

            Console.WriteLine();
        }
    }
}
