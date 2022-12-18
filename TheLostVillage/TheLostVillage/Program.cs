using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheLostVillage
{
    internal class Program
    {
        static Player player = new Player("nAdam");
        static Display display = new Display();
        static ActionHandler actionHandler = new ActionHandler();
        static GameStart game = new GameStart();
        static void Main(string[] args)
        {           
            game.Run();
            for (int i = 0; i < actionHandler.levels.Count; i++)
            {
                display.Stats = player.stats;
                display.OwnedItems = player.Inventory;
                display.LevelHandler = actionHandler.levels[i];
                display.Screen();
            }
            Console.ReadKey();
        }
    }
}

