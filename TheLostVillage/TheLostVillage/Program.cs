using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    internal class Program
    {
        static Player player = new Player("nAdam");
        static Display display = new Display();
        public ActionHandler actionHandler = new ActionHandler();
        static GameStart game = new GameStart();
        static LevelHandler handler = new LevelHandler();
        static void Main(string[] args)
        {           
            game.Run();
            display.LevelHandler = handler;
            display.Screen();
            Console.ReadKey();
        }
    }
}
