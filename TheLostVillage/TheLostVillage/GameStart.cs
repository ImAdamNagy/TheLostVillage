using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheLostVillage
{
    class GameStart
    {
        public void Run()
        {
            MainMenu();
        }
        public void MainMenu()
        {
            string title = "";
            foreach (var item in 
                File.ReadAllLines("title.txt"))
            {
                title += item + "\n";
            }
            ActionHandler action = new ActionHandler();
            string[] options = { "Play", "About the game", "Exit" };
            Menu menu = new Menu(title, options);
            int selected = menu.Run();
            switch (selected)
            {
                case 0:
                    Console.Clear();
                    
                    break;
                case 1:
                    menu.GameInfo();
                    Console.ReadKey();
                    menu.Run();
                    break;
                case 2:
                    menu.ExitGame();
                    break;
                default:
                    break;
            }
        }
        private void MinigameStart()
        {
            Minigame minigame = new Minigame();
            minigame.ShuffleTheLettersOfTheWord();
            minigame.GuessAttempts();
            Console.ReadKey();
        }
    }
}
