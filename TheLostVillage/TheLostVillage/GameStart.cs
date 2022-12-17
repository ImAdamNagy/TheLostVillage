using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLostVillage
{
    class GameStart
    {
        public void Run()
        {
            MainMenu();
            ActionsCall();
        }
        private void ActionsCall()
        {
            ActionHandler actions = new ActionHandler();
            actions.InventoryCall();
        }

        private void MainMenu()
        {
            string title = @"                   (                                                  
  *   )   )        )\ )           )             (  (                  
` )  /(( /(   (   (()/(        ( /(   (   (  (  )\ )\   ) (  (    (   
 ( )(_))\()) ))\   /(_)) (  (  )\())  )\  )\ )\((_|(_| /( )\))(  ))\  
(_(_()|(_)\ /((_) (_))   )\ )\(_))/  ((_)((_|(_)_  _ )(_)|(_))\ /((_) 
|_   _| |(_|_))   | |   ((_|(_) |_   \ \ / / (_) || ((_)_ (()(_|_))   
  | | | ' \/ -_)  | |__/ _ (_-<  _|   \ V /  | | || / _` / _` |/ -_)  
  |_| |_||_\___|  |____\___/__/\__|    \_/   |_|_||_\__,_\__, |\___|  
                                                         |___/        ";
            ActionHandler action = new ActionHandler();
            string[] options = { "Play", "About the game", "Exit" };
            Menu menu = new Menu(title, options);
            int selected = menu.Run();
            switch (selected)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    GameInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
                default:
                    break;
            }
            void ExitGame()
            {
                Environment.Exit(0);
            }
            void GameInfo()
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
                Console.ReadKey(true);
                MainMenu();
            }
            void StartGame()
            {
                action.CallDisplay();
                Console.ReadKey(true);
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
