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
        static Minigame minigame = new Minigame();
        static ActionHandler actionHandler = new ActionHandler();
        static GameStart game = new GameStart();
        static void Main(string[] args)
        {           
            game.Run();
            for (int i = 0; i < actionHandler.levels.Count; i++)
            {
                if (i == 3)
                {
                    Console.Clear();
                    minigame.ShuffleTheLettersOfTheWord();
                    minigame.GuessAttempts();
                }
                else
                {
                    display.Stats = player.stats;
                    display.OwnedItems = player.Inventory;
                    display.LevelHandler = actionHandler.levels[i];
                    display.Screen(false);

                    actionHandler.UserInput(i, display);
                }
            }
            Console.ReadKey();
        }
    }
}

